using AutoMapper;
using DropSpot.Application.Products.Dtos;
using DropSpot.Domain.Entities;
using DropSpot.Domain.Exceptions;
using DropSpot.Domain.Repositories;
using MediatR;

namespace DropSpot.Application.Products.Queries.GetById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<GetProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetByIdAsync(request.Id);
        if(result == null)
        {
            throw new NotFoundException(nameof(Product), request.Id.ToString());
        }

        return _mapper.Map<GetProductDto>(result);

    }
}