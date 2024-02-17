namespace ShopAppAPI.Domain.Entities;

public class Order : BaseEntity<Guid>
{
    public Order()
    {
        Products = new List<Product>();
    }

    public decimal TotalPrice { get; set; }
    public string Address { get; set; }

    // Customer Relation
    public string CustomerId { get; set; }
    public AppUser Customer { get; set; }
    // Product Relation
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
