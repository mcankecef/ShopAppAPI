using System.Linq.Expressions;

namespace ShopAppAPI.Application.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : class, new()
{
    Task<List<T>> GetAllAsync(int page = 1, int pageSize = 10, List<Expression<Func<T, bool>>>? filters = null, params Expression<Func<T, object>>[] includes);
    Task<T> GetByIdAsync(object id);
    IQueryable<T> GetByFilter(Expression<Func<T, bool>> filter, bool isTracked = false, params Expression<Func<T, object>>[] includes);
}
