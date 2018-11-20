using Models.Grabber;
using System.Collections.Generic;

namespace Models.CarInfo
{
    public class UserCar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CarIdCardData CarIdCardData { get; set; }

        public List<PenaltyRecord> PenaltyRecords { get; set; }
    }
}
