using System.Net;
using AutoMapper;
using DropSpot.Application.DataModel;
using DropSpot.Application.DataModel.Requests;
using DropSpot.Application.DataModel.Responses;
using DropSpot.Application.Services.Interfaces;
using DropSpot.Domain.Entities;
using DropSpot.Domain.Repositories;

namespace DropSpot.Application.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResult> CreateAsync(CreateProductServiceRequest request)
    {
        try
        {
            var product = _mapper.Map<Product>(request);
            await _productRepository.CreateAsync(product);
            return ServiceResult.Success();
        }
        catch (Exception ex)
        {
            return ServiceResult.InternalServerError(ex.Message);
        }
    }

    public async Task<ServiceResult<IEnumerable<GetProductServiceResponse>>> GetAllAsync()
    {
        try
        {
            var result = await _productRepository.GetAllAsync();
            var mappedResult = result.Select(product => _mapper.Map<GetProductServiceResponse>(product)).ToList();
            return new ServiceResult<IEnumerable<GetProductServiceResponse>>()
            {
                StatusCode = HttpStatusCode.OK,
                Data = mappedResult,
            };
        }
        catch (Exception ex)
        {
            return new ServiceResult<IEnumerable<GetProductServiceResponse>>()
            {
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
    }

    public async Task<ServiceResult<GetProductServiceResponse>> GetById()
    {
        throw new NotImplementedException();
    }
}