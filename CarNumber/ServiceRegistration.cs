using CarNumber.Configuration;
using DAL;
using DAL.CarIdCard;
using DAL.Registration;
using DAL.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Services.Authentification;
using Services.Mail;
using System.Text;

namespace CarNumber
{
    public static class ServiceRegistration
    {
        public static void RegisterCarNumberServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarAppContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<CarService>();
            services.AddTransient<RegistrationService>();
            services.AddTransient<UserService>();
            services.AddScoped<MailService>();
            services.AddScoped<AuthService>();

            //Configurations
            services.Configure<AppConfiguration>(configuration.GetSection("AppConfiguration"));

            //Authentification
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(configuration.GetSection("AppConfiguration").GetValue<string>("Secret"))
                    ),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
