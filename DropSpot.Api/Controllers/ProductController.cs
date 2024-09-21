using System.Net;
using DropSpot.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DropSpot.Api.Controllers;

[ApiController]
[Route("/api/product")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var result = await _productService.GetAllAsync();
        return result.StatusCode switch
        {
            HttpStatusCode.OK => Ok(result.Data),
            HttpStatusCode.InternalServerError => StatusCode(StatusCodes.Status500InternalServerError),
            _ => throw new NotImplementedException()
        };
    }
}