using DropSpot.Api.Extensions;
using DropSpot.Api.Middlewares;
using DropSpot.Application.Extensions;
using DropSpot.Domain.Entities;
using DropSpot.Infrastructure.Extensions;
using DropSpot.Infrastructure.Seeders;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.AddPresentation();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseMiddleware<ErrorHandlingMiddleware>();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IProductSeeder>();
await seeder.Seed();

app.UseHttpsRedirection();
app.MapControllers();
app.MapGroup("api/identity").MapIdentityApi<User>();
app.UseAuthorization();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());
app.Run();