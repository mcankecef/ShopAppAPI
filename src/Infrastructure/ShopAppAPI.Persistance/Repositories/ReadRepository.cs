using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ShopAppAPI.Application.Repositories;
using ShopAppAPI.Domain;
using ShopAppAPI.Persistance.Contexts;

namespace ShopAppAPI.Persistance.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : class, new()
{
    private readonly ShopAppDbContext _context;

    public ReadRepository(ShopAppDbContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAllAsync() => await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync();

    public async Task<List<T>> GetAllByStatusAsync(StatusTypeEnum statusType) => await _context.Set<T>()
        .AsNoTracking()
        .ToListAsync();

    public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter) => await _context.Set<T>()
                             .AsNoTracking()
                             .FirstOrDefaultAsync(filter);

    public async Task<T> GetByIdAsync(object id) => await _context.Set<T>().FindAsync(id);

    public IQueryable<T> Queryable() => _context.Set<T>().AsQueryable();

    public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        => _context.Set<T>().Where(expression).AsNoTracking();
}
