namespace ShopAppAPI.Domain;

public class BaseEntity
{
    //public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
    public StatusTypeEnum Status { get; set; }
}
