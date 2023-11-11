using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ShopAppAPI.Application.Repositories;
using ShopAppAPI.Persistance.Contexts;

namespace ShopAppAPI.Persistance.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : class, new()
{
    private readonly ShopAppDbContext _context;

    public ReadRepository(ShopAppDbContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAllAsync(int page = 1, int pageSize = 10, List<Expression<Func<T, bool>>>? filters = null, params Expression<Func<T, object>>[] includes)
    {
        var query = _context.Set<T>().AsNoTracking().AsQueryable();

        if (includes != null)
            query = includes.Aggregate(query, (current, include) => current.Include(include));

        if (filters != null && filters.Any())
        {
            // var combinedFilter = filters.Aggregate((current, next) => Expression.Lambda<Func<T, bool>>(
            // Expression.AndAlso(current.Body, next.Body), current.Parameters));
            // query = query.Where(combinedFilter);

            filters.ForEach(filter =>
            {
                query = query.Where(filter);
            });
        }
        if (page > 0 && pageSize > 0)
            query = query.Skip((page - 1) * pageSize).Take(pageSize);

        var result = await query.ToListAsync();
        return result;
    }

    public async Task<IQueryable<T>> GetByFilterAsync(Expression<Func<T, bool>> filter, bool isTracked = false, params Expression<Func<T, object>>[] includes)
    {
        var query = _context.Set<T>().AsQueryable();

        if (!isTracked)
            query = query.AsNoTracking();

        if (includes != null)
            query = includes.Aggregate(query, (current, include) => current.Include(include));

        return query.Where(filter);
    }
    public async Task<T> GetByIdAsync(object id) => await _context.Set<T>().FindAsync(id);

    public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        => _context.Set<T>().Where(expression).AsNoTracking();
}
