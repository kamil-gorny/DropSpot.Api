using System.Net;
using DropSpot.Application.Products;
using DropSpot.Application.Products.Queries.GetAllProducts;
using DropSpot.Application.Products.Queries.GetById;
using DropSpot.Application.Products.Queries.GetProductsByCategory;
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery()
        {
            Id = id
        });
        return Ok(result);
    }
    
    [HttpGet("{category}")]
    public async Task<IActionResult> GetProductsByCategory([FromRoute] string category)
    {
        var result = await _mediator.Send(new GetProductsByCategoryQuery()
        {
            Category = category
        });
        return Ok(result);
    }
}