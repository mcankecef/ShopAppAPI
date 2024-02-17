using MediatR;

namespace ShopAppAPI.Application.Features.AppUserAddressCommandQuery.Queries.GetAppUserAddresses;

public class GetAppUserAddressesQueryRequest : IRequest<BaseResponse<List<GetAppUserAddressesQueryResponse>>>
{
    public string UserId { get; set; }
}
