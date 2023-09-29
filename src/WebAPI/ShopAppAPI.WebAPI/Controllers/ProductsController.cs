using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopAppAPI.Application;
using ShopAppAPI.Application.Features.ProductCommandQuery.Commands;
using ShopAppAPI.Application.Features.ProductCommandQuery.Queries.GetAllProducts;

namespace ShopAppAPI.WebAPI.Controllers;

[ApiController, Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(int page, int pageSize)
        => Ok(await _mediator.Send(new GetAllProductsQueryRequest(page, pageSize)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return StatusCode(201, response);
    }

    [HttpGet("GetAllByCategoryId")]
    public async Task<IActionResult> GetAllByCategoryId(int categoryId, int page, int pageSize)
        => Ok(await _mediator.Send(new GetProductsByCategoryIdQueryRequest(categoryId, page, pageSize)));

}
