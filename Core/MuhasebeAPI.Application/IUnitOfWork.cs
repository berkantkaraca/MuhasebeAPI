 using Microsoft.EntityFrameworkCore;

namespace MuhasebeAPI.Application;

public interface IUnitOfWork
{
    void SetDbContextInstance(DbContext context);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
