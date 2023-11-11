using ShopAppAPI.Application.Repositories;
using ShopAppAPI.Persistance.Contexts;

namespace ShopAppAPI.Persistance.Repositories.Order;

public class OrderReadRepository : ReadRepository<Domain.Entities.Order>, IOrderReadRepository
{
    public OrderReadRepository(ShopAppDbContext context) : base(context)
    {
    }
}
