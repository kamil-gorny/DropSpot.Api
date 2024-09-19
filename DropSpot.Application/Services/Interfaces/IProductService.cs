using DropSpot.Application.DataModel;
using DropSpot.Application.DataModel.Requests;
using DropSpot.Application.DataModel.Responses;

namespace DropSpot.Application.Services.Interfaces;

public interface IProductService
{
    public ServiceResult CreateAsync(CreateProductServiceRequest request);
    public ServiceResult<IEnumerable<GetProductServiceResponse>> GetAllAsync();
    public ServiceResult<GetProductServiceResponse> GetById();
}