using Microsoft.EntityFrameworkCore;

namespace BankContext
{
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options)
            : base(options)
        {

        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
