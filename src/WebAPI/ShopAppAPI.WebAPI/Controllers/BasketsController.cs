using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopAppAPI.Application;

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
    public async Task<IActionResult> Add([FromBody]AddBasketCommandRequest request)
        => Ok(await _mediator.Send(request));
}
