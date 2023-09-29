using MediatR;

namespace ShopAppAPI.Application;

public class GetProductsByCategoryIdQueryRequest : IRequest<BaseResponse<List<GetProductsByCategoryIdResponse>>>
{
    public int CategoryId { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }

    public GetProductsByCategoryIdQueryRequest(int categoryId, int page, int pageSize)
    {
        CategoryId = categoryId;
        Page = page;
        PageSize = pageSize;
    }
}
