using MediatR;

namespace ShopAppAPI.Application.Features.ProductCommandQuery.Queries.GetAllProducts;

public class GetAllProductsQueryRequest : IRequest<BaseResponse<List<GetAllProductQueryResponse>>>
{

}
