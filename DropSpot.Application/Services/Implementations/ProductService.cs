using DropSpot.Application.DataModel;
using DropSpot.Application.DataModel.Requests;
using DropSpot.Application.DataModel.Responses;
using DropSpot.Application.Services.Interfaces;

namespace DropSpot.Application.Services.Implementations;

public class ProductService : IProductService
{
    public ServiceResult CreateAsync(CreateProductServiceRequest request)
    {
        throw new NotImplementedException();
    }

    public ServiceResult<IEnumerable<GetProductServiceResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public ServiceResult<GetProductServiceResponse> GetById()
    {
        throw new NotImplementedException();
    }
}