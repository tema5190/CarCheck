using System.Linq;

namespace DAL.User
{
    public class UserService
    {
        private readonly CarNumberContext userContext;

        public UserService(CarNumberContext context)
        {
            userContext = context;
        }

        public Models.User.User GetUserById(int userId)
        {
            return userContext.Users.FirstOrDefault(user => user.Id == userId);
        }

        public Models.User.User GetUserByEmail(string email)
        {
            return userContext.Users.FirstOrDefault(user => user.Email == email);
        }

        public bool IsUserWithEmailExists(string email)
        {
            return userContext.Users.Any(user => user.Email == email);
        }
    }
}
