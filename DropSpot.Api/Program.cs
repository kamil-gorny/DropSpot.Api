using DropSpot.Application.Extensions;
using DropSpot.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
var app = builder.Build();


app.UseHttpsRedirection();


app.Run();

