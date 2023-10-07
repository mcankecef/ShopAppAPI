using MediatR;

namespace ShopAppAPI.Application.Features.UserCommandQuery.Queries.GetByUserId;
public class GetUserByIdQueryRequest : IRequest<BaseResponse<GetUserByIdQueryResponse>>
{
    public string UserId { get; set; }

    public GetUserByIdQueryRequest(string userId)
    {
        UserId = userId;
    }
}
