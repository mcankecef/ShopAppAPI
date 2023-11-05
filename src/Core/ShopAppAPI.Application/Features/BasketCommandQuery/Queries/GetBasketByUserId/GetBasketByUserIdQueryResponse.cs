using ShopAppAPI.Application.Dtos.Product;

namespace ShopAppAPI.Application.Features.BasketCommandQuery.Queries.GetBasketByUserId;

public class GetBasketByUserIdQueryResponse
{
    public Guid Id { get; set; }
    public List<ProductDto> Products { get; set; }
}
