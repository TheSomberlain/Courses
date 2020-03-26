using Microsoft.EntityFrameworkCore;
namespace _1stWebApp
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Entities.Student> Students { get; set; }
    }
}
