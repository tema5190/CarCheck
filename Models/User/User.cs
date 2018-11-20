using Models.CarInfo;
using System.Collections.Generic;

namespace Models.User
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public UserAuthInfo AuthInfo { get; set; }
        public List<UserCar> UserCars { get; set; }
    }
}
