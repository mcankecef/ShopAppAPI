using ShopAppAPI.Application.Repositories;

namespace ShopAppAPI.Persistance.Repositories;

public class Repository<T> : IRepository<T> where T : class, new()
{

}
