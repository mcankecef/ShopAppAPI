using MediatR;
using ShopAppAPI.Application.Dtos.Product;

namespace ShopAppAPI.Application.Features.ProductCommandQuery.Queries.GetAllProducts;

public class GetAllProductsQueryRequest : IRequest<BaseResponse<List<GetAllProductQueryResponse>>>
{
    public GetAllProductsQueryRequest(int page, int pageSize, ProductFilterDto filter)
    {
        Page = page;
        PageSize = pageSize;
        Filter = filter;
    }

    public int Page { get; set; }
    public int PageSize { get; set; }
    public ProductFilterDto Filter { get; set; }
}
