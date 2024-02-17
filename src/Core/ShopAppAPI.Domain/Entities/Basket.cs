using ShopAppAPI.Domain.Entities;

namespace ShopAppAPI.Domain;

public class Basket : BaseEntity<Guid>
{
    public Basket() => Products = new List<Product>();

    // User Relation
    public string UserId { get; set; }
    public AppUser User { get; set; }

    // Product Relation
    public ICollection<Product> Products { get; set; }
}
