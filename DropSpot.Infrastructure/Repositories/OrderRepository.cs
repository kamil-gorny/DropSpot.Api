using DropSpot.Domain.Entities;
using DropSpot.Domain.Repositories;
using DropSpot.Infrastructure.Peristance;

namespace DropSpot.Infrastructure.Repositories;

internal class OrderRepository : IOrderRepository
{
    private readonly StoreDbContext _dbContext;

    public OrderRepository(StoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<Order?> GetByIdAsync(Guid id)
    {
       var order = await _dbContext.Orders.FindAsync(id);
       return order;
    }

    public async Task<Guid> CreateAsync(Order order)
    {
        await _dbContext.Orders.AddAsync(order);
        await _dbContext.SaveChangesAsync();
        return order.Id;
    }
}