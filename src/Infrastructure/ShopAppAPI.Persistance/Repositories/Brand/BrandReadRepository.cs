using ShopAppAPI.Application.Repositories.Brand;
using ShopAppAPI.Persistance.Contexts;

namespace ShopAppAPI.Persistance.Repositories.Brand;

public class BrandReadRepository : ReadRepository<Domain.Entities.Brand>, IBrandReadRepository
{
    public BrandReadRepository(ShopAppDbContext context) : base(context)
    {
    }
}
