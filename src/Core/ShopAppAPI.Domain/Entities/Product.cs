namespace ShopAppAPI.Domain.Entities;

public class Product : BaseEntity
{
    public Product() => Baskets = new List<Basket>();

    public Guid Id { get; set; }
    public string Name { get; set; }
    public Decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public ICollection<Basket> Baskets { get; set; }
}