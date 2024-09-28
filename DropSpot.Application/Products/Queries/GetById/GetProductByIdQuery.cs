using DropSpot.Application.Products.Dtos;
using MediatR;

namespace DropSpot.Application.Products.Queries.GetById;

public class GetProductByIdQuery : IRequest<GetProductDto>
{
    public Guid Id { get; set; }
}