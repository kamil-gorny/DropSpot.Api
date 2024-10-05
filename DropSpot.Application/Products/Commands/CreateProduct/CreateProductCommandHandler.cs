using AutoMapper;
using DropSpot.Application.Common;
using DropSpot.Domain.Entities;
using DropSpot.Domain.Repositories;
using MediatR;

namespace DropSpot.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository) : IRequestHandler<CreateProductCommand>
{
    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
            var product = mapper.Map<Product>(request);
            await productRepository.CreateAsync(product);
    }
}