using AutoMapper;
using DropSpot.Domain.Entities;

namespace DropSpot.Application.Products.Dtos;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductDto, Product>();
        CreateMap<Product, GetProductDto>();
        CreateMap<AvailableSizes, AvailableSizesDto>();
    }
}