using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopAppAPI.Domain;
using ShopAppAPI.Domain.Entities;

namespace ShopAppAPI.Persistance.Contexts;

public class ShopAppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
{
    public ShopAppDbContext(DbContextOptions<ShopAppDbContext> options) : base(options)
    {

    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Basket> Baskets { get; set; }
}
