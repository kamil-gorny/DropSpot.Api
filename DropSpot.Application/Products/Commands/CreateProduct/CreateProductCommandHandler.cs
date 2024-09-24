using AutoMapper;
using DropSpot.Application.Common;
using DropSpot.Domain.Entities;
using DropSpot.Domain.Repositories;
using MediatR;

namespace DropSpot.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository) : IRequestHandler<CreateProductCommand,ServiceResult>
{
    public async Task<ServiceResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var product = mapper.Map<Product>(request);
            await productRepository.CreateAsync(product);
            return ServiceResult.Success();
        }
        catch (Exception ex)
        {
            return ServiceResult.InternalServerError(ex.Message);
        }
    }
}