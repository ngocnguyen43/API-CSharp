using Microsoft.EntityFrameworkCore;
using WebApi2.Models;

namespace WebApi2.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> orderProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(m => m.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.Property(m => m.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
