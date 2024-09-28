using DropSpot.Domain;
using DropSpot.Domain.Entities;
using DropSpot.Domain.Repositories;
using DropSpot.Infrastructure.Peristance;
using Microsoft.EntityFrameworkCore;

namespace DropSpot.Infrastructure.Repositories;

internal class ProductRepository(StoreDbContext dbContext) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await dbContext.Products.Include(p => p.Sizes).ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await dbContext.Products.FindAsync(id);
    }
    
    public async Task<IEnumerable<Product>> GetByCategoryAsync(string category)
    {
        return await dbContext.Products.Where(p => p.Category == category).ToListAsync();
    }

    public async Task<Guid> CreateAsync(Product product)
    {
        await dbContext.Products.AddAsync(product);
        await dbContext.SaveChangesAsync();
        return product.Id;
    }
    
}