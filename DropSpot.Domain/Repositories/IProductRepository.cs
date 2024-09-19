using DropSpot.Domain.Entities;

namespace DropSpot.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Guid> CreateAsync(Product product);
  
}