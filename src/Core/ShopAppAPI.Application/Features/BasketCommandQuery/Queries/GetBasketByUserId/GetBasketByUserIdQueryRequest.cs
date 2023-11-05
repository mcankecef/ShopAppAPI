using MediatR;

namespace ShopAppAPI.Application.Features.BasketCommandQuery.Queries.GetBasketByUserId;

public class GetBasketByUserIdQueryRequest : IRequest<BaseResponse<GetBasketByUserIdQueryResponse>>
{
    public string UserId { get; set; }

    public GetBasketByUserIdQueryRequest(string userId)
    {
        UserId = userId;
    }
}
