using DropSpot.Application.Services;
using DropSpot.Application.Services.Implementations;
using DropSpot.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DropSpot.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
    }
}