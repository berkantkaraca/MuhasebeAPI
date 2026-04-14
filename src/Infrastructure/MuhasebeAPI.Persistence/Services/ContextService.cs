using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Application.Services;
using MuhasebeAPI.Domain.Entities.App;
using MuhasebeAPI.Persistence.Contexts;

namespace MuhasebeAPI.Persistence.Services;

public sealed class ContextService : IContextService
{
    private readonly AppDbContext _appContext;

    public ContextService(AppDbContext appContext)
    {
        _appContext = appContext;
    }

    public DbContext CreateDbContextInstance(string companyId)
    {
        Company? company = _appContext.Set<Company>().Find(companyId);
        return new CompanyDbContext(company);
    }
}
