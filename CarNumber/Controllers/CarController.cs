using System.Collections.Generic;
using System.Linq;
using DAL.CarIdCard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.CarInfo;
using Models.Grabber;

namespace CarNumber.Controllers
{
    [Route("api/car")]
    [ApiController]
    [Authorize]
    public class CarController : ControllerBase
    {
        private readonly CarService carService;

        public CarController(CarService carIdCardService) {
            carService = carIdCardService;
        }

        [HttpPost("")]
        public void AddCarCardId(CarIdCardData carIdCardInfo)
        {
            var userId = int.Parse(this.User.Identity.Name);
            carService.AddCarCardId(userId, carIdCardInfo);
        }

        [HttpGet("{carId}")]
        public IEnumerable<PenaltyRecord> GetCarPenaltyRecords(int carId)
        {
            var userId = int.Parse(this.User.Identity.Name);
            var result = carService.GetCarPenaltyRecords(userId, carId);
            return result;
        }
    }
}