using DropSpot.Application.Products.Dtos;
using MediatR;

namespace DropSpot.Application.Products.Queries.GetProductsByCategory;

public class GetProductsByCategoryQuery : IRequest<IEnumerable<GetProductDto>>
{
    public string Category { get; set; }
}