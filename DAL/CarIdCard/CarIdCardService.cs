using Grabber;
using Models.CarInfo;
using Models.Grabber;
using Parser;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.CarIdCard
{
    public class CarService
    {
        private readonly CarAppContext context;

        public CarService(CarAppContext context)
        {
            this.context = context;
        }

        public void AddCarCardId(int userId, CarIdCardData carIdCardData)
        {
            var user = this.context.Users.Include(u => u.UserCars).First(u => u.Id == userId);

            var newCar = new UserCar()
            {
                CarIdCardData = carIdCardData,
                Name = "",
                PenaltyRecords = new List<PenaltyRecord>()
            };

            // TODO: Update id without 2 big request to DB
            user.UserCars.Add(newCar);
            context.SaveChanges();

            newCar.PenaltyRecords = GetRemotePenaltyRecords(userId, newCar.Id);
            context.SaveChanges();
        }

        public List<PenaltyRecord> GetCarPenaltyRecords(int userId, int carId)
        {
            var user = context.Users.Include(u => u.UserCars).ThenInclude(c => c.PenaltyRecords).First(u => u.Id == userId);
            return user.UserCars.First(car => car.Id == carId).PenaltyRecords.ToList();
        }

        private List<PenaltyRecord> GetRemotePenaltyRecords(int userId, int carId)
        {
            var user = context.Users.Include(u => u.UserCars).First(u => u.Id == userId);
            var car = user.UserCars.First(c => c.Id == carId);
            var grabber = new MVDGrabber();
            var rawResult = grabber.GetRawData(car.CarIdCardData);
            var parsed = new ResultParser();
            return parsed.ParseResult(rawResult);
        } 
    }
}
