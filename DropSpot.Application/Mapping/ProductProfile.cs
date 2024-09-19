using AutoMapper;
using DropSpot.Application.DataModel.Requests;
using DropSpot.Domain.Entities;

namespace DropSpot.Application.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductServiceRequest, Product>();
    }
}