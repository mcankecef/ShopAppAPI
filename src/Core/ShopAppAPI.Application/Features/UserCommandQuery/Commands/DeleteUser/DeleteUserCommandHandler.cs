using MediatR;

namespace ShopAppAPI.Application.Features.UserCommandQuery.Commands.DeleteUser;
public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, BaseResponse<DeleteUserCommandResponse>>
{
    private readonly IUserService _userService;

    public DeleteUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<BaseResponse<DeleteUserCommandResponse>> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.UserId == null)
            throw new ArgumentNullException($"{request.UserId} is must not null");

        await _userService.DeleteUser(request.UserId);

        return BaseResponse<DeleteUserCommandResponse>.Success(default);
    }
}
