using b2e.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace b2e.Infra.Database
{
    public class b2eContext : DbContext
    {
        public b2eContext(DbContextOptions<b2eContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Product>().ToTable("Products");
        }
    }
}
