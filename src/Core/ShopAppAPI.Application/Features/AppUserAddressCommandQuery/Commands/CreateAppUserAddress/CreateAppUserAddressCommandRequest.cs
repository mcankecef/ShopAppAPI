using MediatR;

namespace ShopAppAPI.Application.Features.AppUserAddressCommandQuery.Commands.CreateAppUserAddress;

public class CreateAppUserAddressCommandRequest : IRequest<BaseResponse<CreateAppUserAddressCommandResponse>>
{
    public string Description { get; set; }
    public string UserId { get; set; }
}
