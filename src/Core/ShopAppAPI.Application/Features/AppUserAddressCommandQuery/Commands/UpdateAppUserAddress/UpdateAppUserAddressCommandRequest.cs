using MediatR;

namespace ShopAppAPI.Application.Features.AppUserAddressCommandQuery.Commands.UpdateAppUserAddress;

public class UpdateAppUserAddressCommandRequest : IRequest<BaseResponse<UpdateAppUserAddressCommandResponse>>
{
    public int AppUserAddressId { get; set; }
    public string Description { get; set; }
}
