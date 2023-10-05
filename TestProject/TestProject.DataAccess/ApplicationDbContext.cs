using Microsoft.EntityFrameworkCore;
using TestProject.DataAccess.Entities;

namespace TestProject.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Entity> Entities { get; set; }
    }
}
