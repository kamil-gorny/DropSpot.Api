using DropSpot.Application.Common;
using DropSpot.Application.Products.Dtos;

namespace DropSpot.Application.Products;

public interface IProductService
{
    Task<ServiceResult> CreateAsync(CreateProductDto request);
    Task<ServiceResult<IEnumerable<GetProductDto>>> GetAllAsync();
    public Task<ServiceResult<GetProductDto>> GetById();
}