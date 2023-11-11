using Microsoft.AspNetCore.Identity;
using ShopAppAPI.Domain.Entities;

namespace ShopAppAPI.Domain;

public class AppUser : IdentityUser
{
    public AppUser() => Orders = new List<Order>();

    public string FullName { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenEndDate { get; set; }

    // Order Relation
    public ICollection<Order> Orders { get; set; }
}
