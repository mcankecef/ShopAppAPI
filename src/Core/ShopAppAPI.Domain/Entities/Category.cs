namespace ShopAppAPI.Domain.Entities;

public class Category : BaseEntity<int>
{
    public Category()
    {
        Products = new List<Product>();
    }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Product> Products { get; set; }
}
