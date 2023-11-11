using ShopAppAPI.Application.Dtos.Product;

namespace ShopAppAPI.Application.Features.OrderCommandQuery.Queries.GetOrdersByUser;

public class GetOrdersByCustomerQueryResponse
{
    public List<ProductDto> Products { get; set; }
    public string Address { get; set; }
    public decimal TotalPrice { get; set; }
}
