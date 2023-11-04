using ShopAppAPI.Application;
using ShopAppAPI.Domain;
using ShopAppAPI.Persistance.Contexts;
using ShopAppAPI.Persistance.Repositories;

namespace ShopAppAPI.Persistance;

public class BasketWriteRepository : WriteRepository<Basket>, IBasketWriteRepository
{
    public BasketWriteRepository(ShopAppDbContext context) : base(context)
    {
    }
}
