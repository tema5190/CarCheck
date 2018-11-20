using CarNumber.Configuration;
using DAL.Helpers;
using DAL.User;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.Auth;
using Models.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Services.Authentification
{
    public class AuthService
    {
        private readonly UserService userService;
        private readonly AppConfiguration appConfiguration;
        public AuthService(UserService userService, IOptions<AppConfiguration> configuration)
        {
            this.userService = userService;
            appConfiguration = configuration.Value;
        }

        public LoginResult Authentificate(LoginModel authModel)
        {
            var user = userService.GetUserByEmail(authModel.Email);
            if (user == null || !IsPasswordValid(authModel.Password, user.AuthInfo))
            {
                return new LoginResult()
                {
                    ErrorMessage = "Email or password isn't valid",
                };
            } else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(appConfiguration.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim(ClaimTypes.Name, user.Id.ToString())
                        }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return new LoginResult()
                {
                    IsSuccess = true,
                    JwtToken = tokenHandler.WriteToken(token),
                };
            }
        }

        private bool IsPasswordValid(string inputPassword, UserAuthInfo authInfo)
        {
            return HashHelper.GetUserPasswordHash(inputPassword, authInfo.Salt) == authInfo.PasswordHash;
        }
    }
}
