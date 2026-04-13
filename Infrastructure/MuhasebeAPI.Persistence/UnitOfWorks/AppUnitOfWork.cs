using MuhasebeAPI.Application.UnitOfWorks;
using MuhasebeAPI.Persistence.Contexts;

namespace MuhasebeAPI.Persistence.UnitOfWorks;

public sealed class AppUnitOfWork : IAppUnitOfWork
{
    private readonly AppDbContext _context;

    public AppUnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) 
        => await _context.SaveChangesAsync(cancellationToken);
}
