using System.Net;
using AutoMapper;
using DropSpot.Application.Common;
using DropSpot.Application.Products.Dtos;
using DropSpot.Domain.Repositories;
using MediatR;

namespace DropSpot.Application.Products.Queries.GetAllProducts;

public class GetAllProdcutsQueryHandler(IMapper mapper, IProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, IEnumerable<GetProductDto>>
{
    
    public async Task<IEnumerable<GetProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
            var result = await productRepository.GetAllAsync();
            return result.Select(product => mapper.Map<GetProductDto>(product)).ToList();
        
    }
}