using MuhasebeAPI.Application.Repositories.GenericRepositories.CompanyDbContextRepositories;
using MuhasebeAPI.Domain.Entities.Company;

namespace MuhasebeAPI.Application.Repositories.CompanyDbContextRepositories.UCAFRepositories;

public interface IUCAFCommandRepository : ICompanyDbCommandRepository<UniformChartOfAccount>
{
}
