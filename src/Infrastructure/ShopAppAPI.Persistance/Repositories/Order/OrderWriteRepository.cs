using ShopAppAPI.Application.Repositories.Order;
using ShopAppAPI.Persistance.Contexts;

namespace ShopAppAPI.Persistance.Repositories;

public class OrderWriteRepository : WriteRepository<Domain.Entities.Order>, IOrderWriteRepository
{
    public OrderWriteRepository(ShopAppDbContext context) : base(context)
    {
    }
}
