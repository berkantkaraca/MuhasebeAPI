using Microsoft.EntityFrameworkCore;

namespace MuhasebeAPI.Application.UnitOfWorks;

public interface ICompanyDbUnitOfWork : IUnitOfWork
{
    void SetDbContextInstance(DbContext context);
}
