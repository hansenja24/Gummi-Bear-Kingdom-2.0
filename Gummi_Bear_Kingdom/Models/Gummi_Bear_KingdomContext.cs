using System;
using Microsoft.EntityFrameworkCore;

namespace Gummi_Bear_Kingdom.Models
{
    public class GummiBearKingdomDbContext : DbContext
    {
        public GummiBearKingdomDbContext()
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=Gummi_Bear_Kingdom;uid=root;pwd=root;");
        }

        public GummiBearKingdomDbContext(DbContextOptions<GummiBearKingdomDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}