using ShopAppAPI.Application.Repositories;
using ShopAppAPI.Domain;
using ShopAppAPI.Domain.Entities;
using ShopAppAPI.Persistance.Contexts;

namespace ShopAppAPI.Persistance.Repositories;

public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
{
    public ProductReadRepository(ShopAppDbContext context) : base(context)
    {
    }
}
