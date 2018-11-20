using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.CarIdCard;
using Microsoft.AspNetCore.Mvc;
using Models.CarInfo;
using Models.Grabber;

namespace CarNumber.Controllers
{
    [Route("api/caridcard")]
    [ApiController]
    public class CarIdCardController : ControllerBase
    {
        private readonly CarIdCardService carIdCardService;

        public CarIdCardController(CarIdCardService carIdCardService) {
            this.carIdCardService = carIdCardService;
        }

        [HttpGet("ping")]
        public string Ping()
        {
            return "pong";
        }

        [HttpGet("carIdCardData")]
        public IEnumerable<PenaltyRecord> GetPenaltyRecords([FromBody]CarIdCardData carIdCardData)
        {
            var result = carIdCardService.GetPenaltyRecords(carIdCardData);
            return result;
        }
    }
}