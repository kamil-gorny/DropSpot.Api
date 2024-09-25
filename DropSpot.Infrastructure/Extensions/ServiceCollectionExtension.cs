using DropSpot.Domain.Repositories;
using DropSpot.Infrastructure.Peristance;
using DropSpot.Infrastructure.Repositories;
using DropSpot.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DropSpot.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<StoreDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("StoreDb")).EnableSensitiveDataLogging();
        });
        
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductSeeder, ProductSeeder>();
    }
}