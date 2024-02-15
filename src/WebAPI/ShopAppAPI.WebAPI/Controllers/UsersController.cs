using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopAppAPI.Application.Features.UserCommandQuery.Commands.DeleteUser;
using ShopAppAPI.Application.Features.UserCommandQuery.Commands.UpdateUser;
using ShopAppAPI.Application.Features.UserCommandQuery.Queries.GetAllUser;
using ShopAppAPI.Application.Features.UserCommandQuery.Queries.GetByUserId;

namespace ShopAppAPI.WebAPI;

[ApiController, Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator) 
        => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllUserQueryRequest()));

    [HttpGet, Route("get-by-id/{userId}")]
    public async Task<IActionResult> GetById(string userId)
        => Ok(await _mediator.Send(new GetUserByIdQueryRequest(userId)));

    [HttpPut]
    public async Task<IActionResult> Update(UpdateUserCommandRequest request)
    {
        await _mediator.Send(request);

        return NoContent();
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> Delete(string userId)
    {
        await _mediator.Send(new DeleteUserCommandRequest(userId));

        return NoContent();
    }
}
