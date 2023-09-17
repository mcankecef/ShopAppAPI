using ShopAppAPI.Application.Repositories;
using ShopAppAPI.Domain.Entities;
using ShopAppAPI.Persistance.Contexts;

namespace ShopAppAPI.Persistance.Repositories;

public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
{
    public ProductWriteRepository(ShopAppDbContext context) : base(context)
    {
    }
}
