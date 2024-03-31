using Microsoft.EntityFrameworkCore;

namespace Lap.Models
{
    public class Context : DbContext
    {
        public Context() { }

        public Context(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product 1", Description = "Description 1", price = 10 },
                new Product { Id = 2, Name = "Product 2", Description = "Description 2", price = 20 },
                new Product { Id = 3, Name = "Product 3", Description = "Description 3", price = 30 },
                new Product { Id = 4, Name = "Product 4", Description = "Description 4", price = 40 },
                new Product { Id = 5, Name = "Product 5", Description = "Description 5", price = 50 }
            );
        }
    }
}

