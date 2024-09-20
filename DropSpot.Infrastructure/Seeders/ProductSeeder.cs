using DropSpot.Domain.Entities;
using DropSpot.Infrastructure.Peristance;

namespace DropSpot.Infrastructure.Seeders;

internal class ProductSeeder : IProductSeeder
{
    private readonly StoreDbContext _dbContext;

    internal ProductSeeder(StoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Seed()
    {
        if (await _dbContext.Database.CanConnectAsync())
        {
            if (_dbContext.Products.Any())
            {
                var products = GetProducts();
                _dbContext.Products.AddRange(products);
                await _dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Product> GetProducts()
    {
        List<Product> products =
        [
            
        ];

        return products;
    }
}