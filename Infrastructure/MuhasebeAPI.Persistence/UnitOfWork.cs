using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Application;
using MuhasebeAPI.Persistence.Contexts;

namespace MuhasebeAPI.Persistence;

public sealed class UnitOfWork : IUnitOfWork
{
    private CompanyDbContext _context = null!;

    public void SetDbContextInstance(DbContext context) => _context = (CompanyDbContext)context;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken) => await _context.SaveChangesAsync(cancellationToken);
}
