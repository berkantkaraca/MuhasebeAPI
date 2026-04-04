using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Application.Repositories;
using MuhasebeAPI.Domain.Abstractions;
using MuhasebeAPI.Persistence.Contexts;
using System.Linq.Expressions;

namespace MuhasebeAPI.Persistence.Repositories;

public class QueryRepository<T> : IQueryRepository<T> where T : BaseEntity
{
    private CompanyDbContext _context = null!;
    public DbSet<T> Table { get; set; } = null!;

    public void SetDbContextInstance(DbContext context)
    {
        _context = (CompanyDbContext)context;
        Table = _context.Set<T>();
    }

    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = Table.AsQueryable();

        if (!tracking)
            query = query.AsNoTracking();

        return query;
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool tracking = true)
    {
        var query = Table.Where(expression);

        if (!tracking)
            query = query.AsNoTracking();

        return query;
    }

    public async Task<T?> GetByIdAsync(string id, bool tracking = true)
    {
        var query = Table.AsQueryable();

        if (!tracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(data => data.Id == id);
    }

    public async Task<T?> GetFirstAsync(bool tracking = true)
    {
        var query = Table.AsQueryable();

        if (!tracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync();
    }

    public async Task<T?> GetFirstByExpiression(Expression<Func<T, bool>> expression, bool tracking = true)
    {
        var query = Table.AsQueryable();

        if (!tracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(expression);
    }
}
