using MuhasebeAPI.Application.Repositories.AppDbContextRepositories.CompanyRepositories;
using MuhasebeAPI.Domain.Entities.App;
using MuhasebeAPI.Persistence.Contexts;
using MuhasebeAPI.Persistence.Repositories.GenericRepositories.AppDbContextRepositories;

namespace MuhasebeAPI.Persistence.Repositories.AppDbContextRepositories.CompanyRepositories;

public sealed class CompanyCommandRepository : AppCommandRepository<Company>, ICompanyCommandRepository
{
    public CompanyCommandRepository(AppDbContext context) : base(context)
    {
    }
}
