using DropSpot.Domain.Entities;

namespace DropSpot.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(Product product);
    Task<IEnumerable<Product>> GetByCategoryAsync(string category);

}