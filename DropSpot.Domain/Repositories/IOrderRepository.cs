using DropSpot.Domain.Entities;

namespace DropSpot.Domain.Repositories;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(Order order);
}