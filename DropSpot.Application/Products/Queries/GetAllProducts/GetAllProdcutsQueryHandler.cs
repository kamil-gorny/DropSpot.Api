using System.Net;
using AutoMapper;
using DropSpot.Application.Common;
using DropSpot.Application.Products.Dtos;
using DropSpot.Domain.Repositories;
using MediatR;

namespace DropSpot.Application.Products.Queries.GetAllProducts;

public class GetAllProdcutsQueryHandler(IMapper mapper, IProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, ServiceResult<IEnumerable<GetProductDto>>>
{
    
    public async Task<ServiceResult<IEnumerable<GetProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await productRepository.GetAllAsync();
            var mappedResult = result.Select(product => mapper.Map<GetProductDto>(product)).ToList();
            return new ServiceResult<IEnumerable<GetProductDto>>()
            {
                StatusCode = HttpStatusCode.OK,
                Data = mappedResult,
            };
        }
        catch (Exception ex)
        {
            return new ServiceResult<IEnumerable<GetProductDto>>()
            {
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
    }
}