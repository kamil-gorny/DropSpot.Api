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
    configuration
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)  
        .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information)  
        .WriteTo.Console(outputTemplate: "[{Timestamp:dd-MM HH:mm:ss} {Level:u3}] |{SourceContext| {NewLine}{Message:lj}{NewLine}{Exception}");
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

