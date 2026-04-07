using MuhasebeAPI.Application.Repositories.AppDbContextRepositories.CompanyRepositories;
using MuhasebeAPI.Domain.Entities.App;
using MuhasebeAPI.Persistence.Contexts;
using MuhasebeAPI.Persistence.Repositories.GenericRepositories.AppDbContextRepositories;

namespace MuhasebeAPI.Persistence.Repositories.AppDbContextRepositories.CompanyRepositories;

public sealed class CompanyQueryRepository : AppQueryRepository<Company>, ICompanyQueryRepository
{
    public CompanyQueryRepository(AppDbContext context) : base(context)
    {
    }
}
