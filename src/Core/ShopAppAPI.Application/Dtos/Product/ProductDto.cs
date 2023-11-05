using ShopAppAPI.Domain;

namespace ShopAppAPI.Application.Dtos.Product;

public class ProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public StatusTypeEnum Status { get; set; } = StatusTypeEnum.Active;
}
