using ShopAppAPI.Application.Repositories.AppUserAddress;
using ShopAppAPI.Persistance.Contexts;

namespace ShopAppAPI.Persistance.Repositories.AppUserAddress;

public class AppUserAddressReadRepository : ReadRepository<Domain.Entities.AppUserAddress>, IAppUserAddressReadRepository
{
    public AppUserAddressReadRepository(ShopAppDbContext context) : base(context)
    {
    }
}
