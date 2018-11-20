using Microsoft.IdentityModel.Tokens;

namespace Models.Auth
{
    public class AuthResult
    {
        public bool IsSuccess { get; set; } = false;
        public string Error { get; set; }
        public string JwtToken { get; set; } = null;
    }
}
