using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopAppAPI.Application;
using ShopAppAPI.Application.Features.BasketCommandQuery.Queries.GetBasketByUserId;

namespace ShopAppAPI.WebAPI;

[ApiController, Route("api/[controller]")]
public class BasketsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BasketsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddBasketCommandRequest request)
        => Ok(await _mediator.Send(request));

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteBasketCommandRequest request)
    {
        await _mediator.Send(request);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string userId)
        => Ok(await _mediator.Send(new GetBasketByUserIdQueryRequest(userId)));
}
