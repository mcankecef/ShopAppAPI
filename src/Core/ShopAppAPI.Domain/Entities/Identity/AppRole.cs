namespace ShopAppAPI.Domain;

public class AppRole
{
    public string FullName { get; set; }
    public Guid? AvatarId { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenEndDate { get; set; }
}
