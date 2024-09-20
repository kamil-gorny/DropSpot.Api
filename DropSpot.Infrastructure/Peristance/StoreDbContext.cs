using DropSpot.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DropSpot.Infrastructure.Peristance;

internal class StoreDbContext(DbContextOptions options) : DbContext(options)
{
    internal DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().HasMany(r => r.Sizes).WithOne().HasForeignKey(s => s.ProductId);
      
    }
}