using MuhasebeAPI.Application.Repositories.GenericRepositories.AppDbContextRepositories;
using MuhasebeAPI.Domain.Entities.App;

namespace MuhasebeAPI.Application.Repositories.AppDbContextRepositories.CompanyRepositories;

public interface ICompanyQueryRepository : IAppQueryRepository<Company>
{
}
