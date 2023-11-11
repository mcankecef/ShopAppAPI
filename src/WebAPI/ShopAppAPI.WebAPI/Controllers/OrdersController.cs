using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopAppAPI.Application.Features.OrderCommandQuery.Commands.CreateOrder;

namespace ShopAppAPI.WebAPI.Controllers;

[ApiController, Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
     => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return StatusCode(201, response);
    }
}
