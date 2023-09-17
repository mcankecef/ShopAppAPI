namespace ShopAppAPI.Domain.Entities;

public class Category : BaseEntity
{
    public Category()
    {
        Products = new List<Product>();
    }
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Product> Products { get; set; }
}
