using System.Net;
using AutoMapper;
using DropSpot.Application.Common;
using DropSpot.Application.Products.Dtos;
using DropSpot.Domain.Entities;
using DropSpot.Domain.Repositories;

namespace DropSpot.Application.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    

    public async Task<ServiceResult<IEnumerable<GetProductDto>>> GetAllAsync()
    {
        try
        {
            var result = await _productRepository.GetAllAsync();
            var mappedResult = result.Select(product => _mapper.Map<GetProductDto>(product)).ToList();
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

    public async Task<ServiceResult<GetProductDto>> GetById()
    {
        throw new NotImplementedException();
    }
}