using MediatR;

namespace ShopAppAPI.Application;

public class GetProductsByCategoryIdQueryRequest : IRequest<BaseResponse<List<GetProductsByCategoryIdResponse>>>
{
    public int CategoryId { get; set; }

    public GetProductsByCategoryIdQueryRequest(int categoryId)
    {
        CategoryId = categoryId;
    }
}
