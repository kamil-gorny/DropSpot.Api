using DropSpot.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructure(builder.Configuration);
var app = builder.Build();


app.UseHttpsRedirection();


app.Run();

