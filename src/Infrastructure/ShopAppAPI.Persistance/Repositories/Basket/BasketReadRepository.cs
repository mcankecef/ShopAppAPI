using ShopAppAPI.Application;
using ShopAppAPI.Domain;
using ShopAppAPI.Persistance.Contexts;
using ShopAppAPI.Persistance.Repositories;

namespace ShopAppAPI.Persistance;

public class BasketReadRepository : ReadRepository<Basket>, IBasketReadRepository
{
    public BasketReadRepository(ShopAppDbContext context) : base(context)
    {
    }
}
