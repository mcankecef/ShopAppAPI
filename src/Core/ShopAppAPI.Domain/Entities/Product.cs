namespace ShopAppAPI.Domain.Entities;

public class Product : BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}