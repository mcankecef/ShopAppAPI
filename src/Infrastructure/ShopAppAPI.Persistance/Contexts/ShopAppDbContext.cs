using Microsoft.EntityFrameworkCore;
using ShopAppAPI.Domain.Entities;

namespace ShopAppAPI.Persistance.Contexts;

public class ShopAppDbContext : DbContext
{
    public ShopAppDbContext(DbContextOptions<ShopAppDbContext> options) : base(options)
    {

    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}
