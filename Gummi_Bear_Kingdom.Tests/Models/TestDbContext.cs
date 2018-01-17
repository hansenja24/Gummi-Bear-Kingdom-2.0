using Microsoft.EntityFrameworkCore;

namespace Gummi_Bear_Kingdom.Models
{
    public class TestDbContext : GummiBearKingdomDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=Gummi_Bear_Kingdom_Test;uid=root;pwd=root;");
        }
    }
}