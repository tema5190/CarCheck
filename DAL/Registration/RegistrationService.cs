using DAL.Helpers;
using DAL.User;
using Models.Mail;
using Models.User;
using Services.Mail;
using System.Linq;

namespace DAL.Registration
{
    public class RegistrationService
    {
        private readonly CarNumberContext carNumberContext;
        private readonly UserService userService;
        private readonly MailService mailService;

        public RegistrationService(CarNumberContext carNumberContext, UserService userService, MailService mailService)
        {
            this.carNumberContext = carNumberContext;
            this.userService = userService;
            this.mailService = mailService;
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

            carNumberContext.Users.Add(user);
            carNumberContext.SaveChanges();

            (string, string) emailConfirmationHashes = HashHelper.GetHashesForEmailConfirmation(user.Email);
            var confirmationEmailModel = new ConfirmationModel()
            {
                Email = user.Email,
                UserId = user.Id,
                Hash1 = emailConfirmationHashes.Item1,
                Hash2 = emailConfirmationHashes.Item2,
            };

            // Check and add transaction
            this.mailService.SendEmailConfirmationEmail(
                confirmationEmailModel.Email, $"{confirmationEmailModel.Hash1}/{confirmationEmailModel.Hash2}"
            );

            this.carNumberContext.ConfirmationModels.Add(confirmationEmailModel);
            carNumberContext.SaveChanges();

            // TODO: here...

            return true;
        }

        public bool ConfirmEmail(string hash1, string hash2)
        {
            ConfirmationModel confirmationRecord = carNumberContext.ConfirmationModels.FirstOrDefault(record => record.Hash1 == hash1);

            if(confirmationRecord == null) return false;

            if(confirmationRecord.Hash2 == hash2)
            {
                var user = this.userService.GetUserById(confirmationRecord.UserId);
                user.IsEmailConfirmed = true;
                this.carNumberContext.Remove(confirmationRecord);
                this.carNumberContext.SaveChanges();
                return true;
            }

            return false;
        }

        public Models.User.User GetUserById(int userId)
        {
            return this.userService.GetUserById(userId);
        }
    }
}
