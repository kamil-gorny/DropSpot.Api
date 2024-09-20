using DropSpot.Application.DataModel;
using DropSpot.Application.DataModel.Requests;
using DropSpot.Application.DataModel.Responses;

namespace DropSpot.Application.Services.Interfaces;

public interface IProductService
{
    Task<ServiceResult> CreateAsync(CreateProductServiceRequest request);
    Task<ServiceResult<IEnumerable<GetProductServiceResponse>>> GetAllAsync();
    public Task<ServiceResult<GetProductServiceResponse>> GetById();
}