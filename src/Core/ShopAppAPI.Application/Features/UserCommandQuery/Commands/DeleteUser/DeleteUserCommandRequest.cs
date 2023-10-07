using MediatR;

namespace ShopAppAPI.Application.Features.UserCommandQuery.Commands.DeleteUser;
public class DeleteUserCommandRequest : IRequest<BaseResponse<DeleteUserCommandResponse>>
{
    public string UserId { get; set; }

    public DeleteUserCommandRequest(string userId)
    {
        UserId = userId;
    }
}
