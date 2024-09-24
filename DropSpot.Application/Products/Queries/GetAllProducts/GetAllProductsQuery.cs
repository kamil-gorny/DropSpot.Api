using DropSpot.Application.Common;
using DropSpot.Application.Products.Dtos;
using MediatR;

namespace DropSpot.Application.Products.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<ServiceResult<IEnumerable<GetProductDto>>>
{
    
}