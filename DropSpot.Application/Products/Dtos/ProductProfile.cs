using AutoMapper;
using DropSpot.Application.Products.Commands;
using DropSpot.Application.Products.Commands.CreateProduct;
using DropSpot.Domain.Entities;

namespace DropSpot.Application.Products.Dtos;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductCommand, Product>();
        CreateMap<Product, GetProductDto>();
        CreateMap<AvailableSizes, AvailableSizesDto>();
    }
}