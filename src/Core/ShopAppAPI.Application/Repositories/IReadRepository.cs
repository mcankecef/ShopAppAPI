using ShopAppAPI.Domain;
using System.Linq.Expressions;

namespace ShopAppAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : class ,new()
    {
        Task<List<T>> GetAllAsync(int? page, int? pageSize, Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(object id);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
        IQueryable<T> Queryable();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}
