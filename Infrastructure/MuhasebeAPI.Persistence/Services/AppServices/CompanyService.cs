using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using MuhasebeAPI.Application.Repositories.AppDbContextRepositories.CompanyRepositories;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Application.UnitOfWorks;
using MuhasebeAPI.Domain.Entities.App;
using MuhasebeAPI.Persistence.Contexts;

namespace MuhasebeAPI.Persistence.Services.AppServices;

public class CompanyService : ICompanyService
{
    private readonly ICompanyCommandRepository _companyCommandRepository;
    private readonly ICompanyQueryRepository _companyQueryRepository;
    private readonly IAppUnitOfWork _appUnitOfWork;
    private readonly IMapper _mapper;
    public CompanyService(IMapper mapper, ICompanyCommandRepository companyCommandRepository, ICompanyQueryRepository companyQueryRepository, IAppUnitOfWork appUnitOfWork)
    {
        _mapper = mapper;
        _companyCommandRepository = companyCommandRepository;
        _companyQueryRepository = companyQueryRepository;
        _appUnitOfWork = appUnitOfWork;
    }

    public async Task CreateCompany(CreateCompanyCommandRequest request, CancellationToken cancellationToken)
    {
        Company company = _mapper.Map<Company>(request);
        company.Id = Guid.NewGuid().ToString();

        await _companyCommandRepository.AddAsync(company, cancellationToken);
        await _appUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<Company?> GetCompanyByName(string name)
    {
        return await _companyQueryRepository.GetFirstByExpiressionAsync(p => p.Name == name);
    }

    public async Task MigrateCompanyDatabases()
    {
        var companies = await _companyQueryRepository.GetAll().ToListAsync();

        foreach (var company in companies)
        {
            CompanyDbContext db = new CompanyDbContext(company);
            db.Database.Migrate();
        }
    }
}
