﻿using Grabber;
using Models.CarInfo;
using Models.Grabber;
using Parser;
using System.Collections.Generic;

namespace DAL.CarIdCard
{
    public class CarIdCardService
    {
        private readonly UserContext userContext;

        public CarIdCardService(UserContext context)
        {
            userContext = context;
        }

        public List<PenaltyRecord> GetPenaltyRecords(CarIdCardData carIdCard)
        {
            var grabber = new MVDGrabber();
            var rawResult = grabber.GetRawData(carIdCard);
            var parsed = new ResultParser();
            return parsed.ParseResult(rawResult);
        } 
    }
}
