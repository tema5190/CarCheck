namespace Models.CarInfo
{
    public class UserCar
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public CarIdCardData CarIdCardData { get; set; }
        public int? PenaltyCount { get; set; }
    }
}
