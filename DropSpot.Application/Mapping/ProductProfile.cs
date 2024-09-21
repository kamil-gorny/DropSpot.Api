using AutoMapper;
using DropSpot.Application.DataModel.Requests;
using DropSpot.Application.DataModel.Responses;
using DropSpot.Domain.Entities;

namespace DropSpot.Application.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductServiceRequest, Product>();
        CreateMap<Product, GetProductServiceResponse>();
        CreateMap<AvailableSizes, AvailableSizesResponseModel>();
    }
}