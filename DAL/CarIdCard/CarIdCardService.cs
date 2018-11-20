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
            var newCar = new UserCar()
            {
                UserId = userId,
                CarIdCardData = carIdCardData,
                Name = "",
            };

            context.Cars.Add(newCar);
            context.SaveChanges();
            // TODO: Update db in one time without 2 records
            //context.Entry(newCar).GetDatabaseValues();

            var initCarRecords = GetRemotePenaltyRecords(userId, newCar.Id);
            context.PenaltyRecords.AddRange(initCarRecords);
            context.SaveChanges();
        }

        public List<PenaltyRecord> GetCarPenaltyRecords(int userId, int carId)
        {
            // TODO: Load not own car records protect problem?
            var records = context.PenaltyRecords.Where(record => record.CarId == carId).ToList();
            return records;
        }

        private List<PenaltyRecord> GetRemotePenaltyRecords(int userId, int carId)
        {
            // TODO: Load not own car records protect problem?
            var car = context.Cars.First(c => c.Id == carId);
            var grabber = new MVDGrabber();
            var rawResult = grabber.GetRawData(car.CarIdCardData);
            var parsed = new ResultParser();
            return parsed.ParseResult(rawResult, carId);
        } 
    }
}
