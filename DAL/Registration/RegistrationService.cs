using DAL.Helpers;
using DAL.User;
using Models.User;

namespace DAL.Registration
{
    public class RegistrationService
    {
        private readonly UserContext userContext;
        private readonly UserService userService;

        public RegistrationService(UserContext userContext, UserService userService)
        {
            this.userContext = userContext;
            this.userService = userService;
        }

        public bool CreateNewUser(RegistrationModel registrationModel)
        {
            if(userService.IsUserWithEmailExists(registrationModel.Email))
            {
                return false;
            }

            var user = new Models.User.User()
            {
                Email = registrationModel.Email,
                AuthInfo = HashHelper.GetNewUserAuthInfo(registrationModel.Password),
                UserCars = new System.Collections.Generic.List<Models.CarInfo.UserCar>()
            };

            userContext.Users.Add(user);
            userContext.SaveChanges();

            // TODO: here...

            return true;
        }

        public Models.User.User GetUserById(int userId)
        {
            return this.userService.GetUserById(userId);
        }
    }
}
