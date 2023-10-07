using Microsoft.AspNetCore.Identity;

namespace ShopAppAPI.Domain;

public class AppUser : IdentityUser
{
    public string FullName { get; set; }
    public Guid? AvatarId { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenEndDate { get; set; }
}
