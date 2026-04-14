using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Application.UnitOfWorks;
using MuhasebeAPI.Persistence.Contexts;

namespace MuhasebeAPI.Persistence.UnitOfWorks;

public sealed class CompanyDbUnitOfWork : ICompanyDbUnitOfWork
{
    private CompanyDbContext _context = null!;

    public void SetDbContextInstance(DbContext context)
    {
        _context = (CompanyDbContext)context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken) 
        => await _context.SaveChangesAsync(cancellationToken);
}
