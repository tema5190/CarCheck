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
    public class AuthController : ControllerBase
    {
        private readonly AuthService authService;
        public AuthController(AuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("authentificate")]
        public AuthResult Authentificate(AuthModel authModel)
        {
            return authService.Authentificate(authModel);
        }
    }
}