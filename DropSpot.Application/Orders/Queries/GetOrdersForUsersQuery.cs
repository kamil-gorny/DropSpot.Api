using DropSpot.Domain.Entities;
using MediatR;

namespace DropSpot.Application.Orders.Queries;

public class GetOrdersForUsersQuery : IRequest<IEnumerable<Order>>
{
    
}