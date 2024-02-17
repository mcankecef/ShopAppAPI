namespace ShopAppAPI.Domain.Entities;

public class Brand : BaseEntity<int>
{
    public Brand()
    {
        Brands = new List<Brand>();
    }

    public string Name { get; set; }
    public string? Description { get; set; }

    // Product Relation
    public ICollection<Brand> Brands { get; set; }

}
