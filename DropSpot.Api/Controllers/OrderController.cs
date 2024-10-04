using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DropSpot.Api.Controllers;

[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrder command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrdersForUsers([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetOrdersForUsers()
        {
            Id = id
        });
        return Ok(result);
    }

}