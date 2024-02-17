using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopAppAPI.Application.Features.BrandCommandQuery.Commands.CreateBrand;

namespace ShopAppAPI.WebAPI.Controllers;

[ApiController, Route("api/[controller]")]
public class BrandsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BrandsController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBrandCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return StatusCode(201, response);
    }
}
