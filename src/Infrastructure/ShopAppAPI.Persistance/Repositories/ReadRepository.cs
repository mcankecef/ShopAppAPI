﻿using System.Linq.Expressions;
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

    public async Task<List<T>> GetAllAsync(int page = 1, int pageSize = 10, Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includes)
    {
        var query = _context.Set<T>().AsNoTracking();

        if (includes != null)
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        if (filter != null)
            query = query.Where(filter);
        if (page > 0 && pageSize > 0)
            query = query.Skip((page - 1) * pageSize).Take(pageSize);

        return await query.ToListAsync();
    }

    public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter) => await _context.Set<T>()
                             .AsNoTracking()
                             .FirstOrDefaultAsync(filter);

    public async Task<T> GetByIdAsync(object id) => await _context.Set<T>().FindAsync(id);

    public IQueryable<T> Queryable() => _context.Set<T>().AsQueryable();

    public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        => _context.Set<T>().Where(expression).AsNoTracking();
}
