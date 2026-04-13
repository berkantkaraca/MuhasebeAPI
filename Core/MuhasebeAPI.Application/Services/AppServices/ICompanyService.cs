using MuhasebeAPI.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using MuhasebeAPI.Domain.Entities.App;

namespace MuhasebeAPI.Application.Services.AppServices;

public interface ICompanyService
{
    Task CreateCompany(CreateCompanyCommandRequest request, CancellationToken cancellationToken);
    Task MigrateCompanyDatabases();
    Task<Company?> GetCompanyByNameAsync(string name, CancellationToken cancellationToken);
    IQueryable<Company> GetAll();
}
