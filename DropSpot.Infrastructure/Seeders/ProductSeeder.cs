using DropSpot.Domain.Entities;
using DropSpot.Infrastructure.Peristance;

namespace DropSpot.Infrastructure.Seeders;

internal class ProductSeeder(StoreDbContext dbContext) : IProductSeeder
{
  

    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Products.Any())
            {
                var products = GetProducts();
                dbContext.Products.AddRange(products);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Product> GetProducts()
    {
        List<Product> products =
        [
            new ()
            {
                Id = new Guid("5AEC8886-187F-48D7-B504-F1EF7F50642A"),
                Category = "T-shirt",
                Color = "black",
                Description = "All cotton classic Supreme t-shirt with printed logos on chest.",
                ImageUrl = "https://eu.supreme.com/cdn/shop/files/T14_FW24_MartineLogoTee_Black_720x.jpg?v=1725911179",
                Name = "Custom T-shirt",
                Price = "46",
                Sizes =
                [
                    new()
                    {
                        Id = new Guid("B8CBF71B-7818-4CB5-834F-531E246CEAED"),
                        ProductId = new Guid("5AEC8886-187F-48D7-B504-F1EF7F50642A"),
                        Quantity = 5,
                        Size = Size.XLarge
                    }
                ]

            }
            
        ];

        return products;
    }
}