namespace ShopAppAPI.Domain.Entities;

public class Product : BaseEntity<Guid>
{
    public Product()
    {
        Baskets = new List<Basket>();
        Orders = new List<Order>();
    }

    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }

    // Category Relation
    public Category Category { get; set; }
    // Basket Relation
    public ICollection<Basket> Baskets { get; set; }
    // Order Relation
    public ICollection<Order> Orders { get; set; }
}