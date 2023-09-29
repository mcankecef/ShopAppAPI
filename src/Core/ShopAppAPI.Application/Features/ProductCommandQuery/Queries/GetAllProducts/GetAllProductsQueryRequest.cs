using MediatR;

namespace ShopAppAPI.Application.Features.ProductCommandQuery.Queries.GetAllProducts;

public class GetAllProductsQueryRequest : IRequest<BaseResponse<List<GetAllProductQueryResponse>>>
{
    public GetAllProductsQueryRequest(int page, int pageSize)
    {
        Page = page;
        PageSize = pageSize;
    }

    public int Page { get; set; }
    public int PageSize { get; set; }
}
