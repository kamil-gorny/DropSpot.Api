using DropSpot.Application.Extensions;
using DropSpot.Infrastructure.Extensions;
using DropSpot.Infrastructure.Seeders;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});
var app = builder.Build();
app.UseSerilogRequestLogging();
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IProductSeeder>();
await seeder.Seed();

app.UseHttpsRedirection();
app.MapControllers();
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials());
app.Run();

