using MediatR;

namespace ShopAppAPI.Application.Features.AuthCommandQuery.LoginUser;
public class LoginUserCommandRequest : IRequest<BaseResponse<LoginUserCommandResponse>>
{
    public string UsernameOrEmail { get; set; }
    public string Password { get; set; }
}
