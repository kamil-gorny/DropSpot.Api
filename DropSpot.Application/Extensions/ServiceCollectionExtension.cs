using DropSpot.Application.Products;
using Microsoft.Extensions.DependencyInjection;

namespace DropSpot.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddAutoMapper(typeof(ServiceCollectionExtension).Assembly);
    }
}