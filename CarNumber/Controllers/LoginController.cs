using DAL.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Auth;
using Services.Authentification;

namespace CarNumber.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly AuthService authService;
        public LoginController(AuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("authentificate")]
        public LoginResult Authentificate(LoginModel authModel)
        {
            return authService.Authentificate(authModel);
        }
    }
}