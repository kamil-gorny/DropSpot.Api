using System.Net;
using DropSpot.Application.Products;
using DropSpot.Application.Products.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DropSpot.Api.Controllers;

[ApiController]
[Route("/api/product")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var result = await _mediator.Send(new GetAllProductsQuery());
        return result.StatusCode switch
        {
            HttpStatusCode.OK => Ok(result.Data),
            HttpStatusCode.InternalServerError => StatusCode(StatusCodes.Status500InternalServerError),
            _ => throw new NotImplementedException()
        };
    }
}