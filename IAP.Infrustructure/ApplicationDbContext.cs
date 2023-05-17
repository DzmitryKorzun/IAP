using IAP.Infrustructure.Models;
using Microsoft.EntityFrameworkCore;

namespace IAP.Infrustructure
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<UserModel> Users { get; set; }
    }
}