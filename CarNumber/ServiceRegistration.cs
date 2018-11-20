using DAL;
using DAL.CarIdCard;
using DAL.Registration;
using DAL.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Mail;

namespace CarNumber
{
    public static class ServiceRegistration
    {
        public static void RegisterCarNumberServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<CarIdCardService>();
            services.AddTransient<RegistrationService>();
            services.AddTransient<UserService>();
            services.AddScoped<MailService>();
        }
    }
}
