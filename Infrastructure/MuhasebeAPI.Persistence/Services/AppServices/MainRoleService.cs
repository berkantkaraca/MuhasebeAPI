using MuhasebeAPI.Application.Repositories.AppDbContextRepositories.MainRoleReporistories;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Application.UnitOfWorks;
using MuhasebeAPI.Domain.Entities.App;

namespace MuhasebeAPI.Persistence.Services.AppServices;

public sealed class MainRoleService : IMainRoleService
{
    private readonly IMainRoleCommandRepository _mainRoleCommandRepository;
    private readonly IMainRoleQueryRepository _mainRoleQueryRepository;
    private readonly IAppUnitOfWork _unitOfWork;

    public MainRoleService(IMainRoleCommandRepository mainRoleCommandRepository, IMainRoleQueryRepository mainRoleQueryRepository, IAppUnitOfWork unitOfWork)
    {
        _mainRoleCommandRepository = mainRoleCommandRepository;
        _mainRoleQueryRepository = mainRoleQueryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(MainRole mainRole, CancellationToken cancellationToken)
    {
        await _mainRoleCommandRepository.AddAsync(mainRole, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task CreateRangeAsync(List<MainRole> newMainRoles, CancellationToken cancellationToken)
    {
        await _mainRoleCommandRepository.AddRangeAsync(newMainRoles, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<MainRole> GetAll()
        => _mainRoleQueryRepository.GetAll();

    public async Task<MainRole> GetByIdAsync(string id)
        => await _mainRoleQueryRepository.GetByIdAsync(id);

    public async Task<MainRole> GetByTitleAndCompanyIdAsync(string title, string companyId, CancellationToken cancellationToken)
        => (await _mainRoleQueryRepository.GetFirstByExpiressionAsync(p => p.Title == title && p.CompanyId == companyId, cancellationToken, false))!;

    public async Task RemoveByIdAsync(string id)
    {
        await _mainRoleCommandRepository.RemoveAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(MainRole mainRole)
    {
        _mainRoleCommandRepository.Update(mainRole);
        await _unitOfWork.SaveChangesAsync();
    }
}
