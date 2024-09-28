using AutoMapper;
using DropSpot.Application.Products.Dtos;
using DropSpot.Domain.Repositories;
using MediatR;

namespace DropSpot.Application.Products.Queries.GetProductsByCategory;

public class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategoryQuery, IEnumerable<GetProductDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductsByCategoryQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetProductDto>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetByCategoryAsync(request.Category);
        return _mapper.Map<IEnumerable<GetProductDto>>(products);
    }
}