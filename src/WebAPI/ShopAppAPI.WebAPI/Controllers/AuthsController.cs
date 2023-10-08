using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopAppAPI.Application.Features.AuthCommandQuery.LoginUser;
using ShopAppAPI.Application.Features.AuthCommandQuery.RefreshToken;
using ShopAppAPI.Application.Features.UserCommandQuery.Commands.CreateUser;

namespace ShopAppAPI.WebAPI;

[ApiController, Route("api/[controller]")]
public class AuthsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthsController(IMediator mediator)
        => _mediator = mediator;

    [HttpPost, Route("Login")]
    public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        => Ok(await _mediator.Send(loginUserCommandRequest));

    [HttpPost, Route("RefreshTokenLogin")]
    public async Task<IActionResult> RefreshTokenLogin(RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest)
        => Ok(await _mediator.Send(refreshTokenLoginCommandRequest));

    [HttpPost, Route("Register")]
    public async Task<IActionResult> Register(CreateUserCommandRequest createUserCommandRequest)
        => Ok(await _mediator.Send(createUserCommandRequest));
}
