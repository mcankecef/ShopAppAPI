using ShopAppAPI.Application.Repositories.AppUserAddress;
using ShopAppAPI.Persistance.Contexts;

namespace ShopAppAPI.Persistance.Repositories.AppUserAddress;

public class AppUserAddressWriteRepository : WriteRepository<Domain.Entities.AppUserAddress>, IAppUserAddressWriteRepository
{
    public AppUserAddressWriteRepository(ShopAppDbContext context) : base(context)
    {
    }
}
