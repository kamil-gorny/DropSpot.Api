using DropSpot.Application.DataModel;

namespace DropSpot.Application.Services.Interfaces;

public interface IProductService
{
    public ServiceResult CreateAsync();
    public ServiceResult<IEnumerable<GetProductServiceResponse>> GetAllAsync();
    public ServiceResult<GetProductServiceResponse> GetById();
}