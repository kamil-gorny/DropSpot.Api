using DropSpot.Application.Extensions;
using DropSpot.Infrastructure.Extensions;
using DropSpot.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
var app = builder.Build();
//
// var scope = app.Services.CreateScope();
// var seeder = scope.ServiceProvider.GetRequiredService<IProductSeeder>();
// await seeder.Seed();

app.UseHttpsRedirection();


app.Run();

