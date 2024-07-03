using MediatR;

namespace ShopAppAPI.Application.Features.AppUserAddressCommandQuery.Commands.DeleteAppUserAddress;

public class DeleteAppUserAddressCommandRequest : IRequest<BaseResponse<DeleteAppUserAddressCommandResponse>>
{
    public int Id { get; set; }
}
