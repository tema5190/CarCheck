using Microsoft.EntityFrameworkCore;
using Models.Mail;
using Models.User;

namespace DAL
{
    public class CarNumberContext: DbContext
    {
        public CarNumberContext(DbContextOptions<CarNumberContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<ConfirmationModel> ConfirmationModels { get; set; }
    }
}
