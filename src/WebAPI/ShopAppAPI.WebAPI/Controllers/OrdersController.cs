using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopAppAPI.Application.Features.OrderCommandQuery.Commands.CreateOrder;
using ShopAppAPI.Application.Features.OrderCommandQuery.Queries.GetOrdersByUser;

namespace ShopAppAPI.WebAPI.Controllers;

[ApiController, Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-orders-by-customer")]
    public async Task<IActionResult> GetOrdersByCustomer([FromQuery] string customerId)
        => Ok(await _mediator.Send(new GetOrdersByCustomerQueryRequest(customerId)));

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return StatusCode(201, response);
    }
}
