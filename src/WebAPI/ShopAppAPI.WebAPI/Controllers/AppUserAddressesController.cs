using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopAppAPI.Application.Features.AppUserAddressCommandQuery.Commands.CreateAppUserAddress;
using ShopAppAPI.Application.Features.AppUserAddressCommandQuery.Commands.UpdateAppUserAddress;
using ShopAppAPI.Application.Features.AppUserAddressCommandQuery.Queries.GetAppUserAddresses;

namespace ShopAppAPI.WebAPI.Controllers;

[ApiController, Route("api/[controller]")]
public class AppUserAddressesController : ControllerBase
{
    private readonly IMediator _mediator;

    public AppUserAddressesController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetAll(string userId)
        => Ok(await _mediator.Send(new GetAppUserAddressesQueryRequest { UserId = userId }));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAppUserAddressCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return StatusCode(201, response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAppUserAddressCommandRequest request)
    {
        await _mediator.Send(request);
        return NoContent();
    }
}

