using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Application.Repositories;
using MuhasebeAPI.Domain.Abstractions;
using MuhasebeAPI.Persistence.Contexts;

namespace MuhasebeAPI.Persistence.Repositories;

public class CommandRepository<T> : ICommandRepository<T> where T : BaseEntity
{
    private CompanyDbContext _context = null!;
    public DbSet<T> Table { get; set; } = null!;

    public void SetDbContextInstance(DbContext context)
    { 
        _context = (CompanyDbContext)context;
        Table = _context.Set<T>();
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken) => await Table.AddAsync(entity, cancellationToken);

    public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken) => await Table.AddRangeAsync(entities, cancellationToken);

    public void Update(T entity) => Table.Update(entity);

    public void UpdateRange(IEnumerable<T> entities) =>  Table.UpdateRange(entities);

    public void Remove(T entity) => Table.Remove(entity);

    public async Task RemoveAsync(string id)
    {
        T? entity = await Table.FirstOrDefaultAsync(p => p.Id == id);

        if (entity is not null)
            Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities) =>Table.RemoveRange(entities);

    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
}
