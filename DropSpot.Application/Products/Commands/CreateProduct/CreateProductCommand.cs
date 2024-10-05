using DropSpot.Application.Common;
using MediatR;

namespace DropSpot.Application.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Price { get; set; }
    public required string Description { get; set; }
    public required string Category { get; set; }
    public required string Color { get; set; }
    public required string ImageUrl { get; set; }
}