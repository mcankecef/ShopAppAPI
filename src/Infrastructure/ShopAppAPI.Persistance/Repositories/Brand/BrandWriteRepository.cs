using ShopAppAPI.Application.Repositories.Brand;
using ShopAppAPI.Persistance.Contexts;

namespace ShopAppAPI.Persistance.Repositories.Brand;

public class BrandWriteRepository : WriteRepository<Domain.Entities.Brand>, IBrandWriteRepository
{
    public BrandWriteRepository(ShopAppDbContext context) : base(context)
    {
    }
}
