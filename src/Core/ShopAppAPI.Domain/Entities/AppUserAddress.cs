namespace ShopAppAPI.Domain.Entities;

public class AppUserAddress : BaseEntity<int>
{
    public string Description { get; set; }

    // AppUser Relation
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
}
