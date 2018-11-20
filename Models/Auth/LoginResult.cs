using Microsoft.IdentityModel.Tokens;

namespace Models.Auth
{
    public class LoginResult
    {
        public bool IsSuccess { get; set; } = false;
        public string ErrorMessage { get; set; }
        public string JwtToken { get; set; } = null;
    }
}
