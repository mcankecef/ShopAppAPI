using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopAppAPI.Application;
using ShopAppAPI.Application.Features.ProductCommandQuery.Commands.CreateProduct;
using ShopAppAPI.Application.Features.ProductCommandQuery.Queries.GetAllProducts;

namespace ShopAppAPI.WebAPI.Controllers;

[ApiController, Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator) => _mediator = mediator;

    [HttpPost,Route("GetAll")]
    public async Task<IActionResult> GetAll(GetAllProductsQueryRequest request)
        => Ok(await _mediator.Send(request));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return StatusCode(201, response);
    }

    [HttpGet("GetAllByCategoryId")]
    public async Task<IActionResult> GetAllByCategoryId(int categoryId, int page, int pageSize)
        => Ok(await _mediator.Send(new GetProductsByCategoryIdQueryRequest(categoryId, page, pageSize)));

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductCommandRequest request)
    {
        await _mediator.Send(request);
        return NoContent();
    }

}
