using MediatR;

namespace ShopAppAPI.Application.Features.UserCommandQuery.Commands.UpdateUser;
public class UpdateUserCommandRequest : IRequest<BaseResponse<UpdateUserCommandResponse>>
{
    public UpdateUserCommandRequest(string userId, string fullName, string? email)
    {
        UserId = userId;
        FullName = fullName;
        Email = email;
    }
    public string UserId { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public Guid? AvatarId { get; set; }
}
