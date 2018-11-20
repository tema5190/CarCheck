using Models.CarInfo;
using System;

namespace Models.Grabber
{
    public class PenaltyRecord
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public DateTime PenaltyDataTime { get; set; }
        public string PenaltyNumber { get; set; }
    }
}
