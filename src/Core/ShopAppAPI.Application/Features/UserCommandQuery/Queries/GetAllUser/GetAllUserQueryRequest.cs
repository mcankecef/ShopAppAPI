using MediatR;

namespace ShopAppAPI.Application.Features.UserCommandQuery.Queries.GetAllUser;
public class GetAllUserQueryRequest : IRequest<BaseResponse<List<GetAllUserQueryResponse>>>
{
}