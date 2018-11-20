using Models.CarInfo;
using System;

namespace Models.Grabber
{
    public class PenaltyRecord : CarIdCardData
    {
        public DateTime PenaltyDataTime { get; set; }
        public string PenaltyNumber { get; set; }
    }
}
