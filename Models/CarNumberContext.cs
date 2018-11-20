using Microsoft.EntityFrameworkCore;
using Models.CarInfo;
using Models.Grabber;
using Models.Mail;
using Models.User;

namespace DAL
{
    public class CarAppContext: DbContext
    {
        public CarAppContext(DbContextOptions<CarAppContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<UserCar> Cars { get; set; }

        public DbSet<PenaltyRecord> PenaltyRecords { get; set; }

        public DbSet<ConfirmationModel> ConfirmationModels { get; set; }
    }
}
