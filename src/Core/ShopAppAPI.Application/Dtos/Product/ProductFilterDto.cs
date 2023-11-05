namespace ShopAppAPI.Application.Dtos.Product;

public class ProductFilterDto
{
    public string? Name { get; set; } = null;
    public decimal? Price { get; set; } = null;
    public int? CategoryId { get; set; } = null;
}
