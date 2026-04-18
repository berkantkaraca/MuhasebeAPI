using MuhasebeAPI.Application.Repositories.AppDbContextRepositories.MainRoleAndUserRelationshipRepositories;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Application.UnitOfWorks;
using MuhasebeAPI.Domain.Entities.App;

namespace MuhasebeAPI.Persistence.Services.AppServices;

public class MainRoleAndUserRelationshipService : IMainRoleAndUserRelationshipService
{
    private readonly IMainRoleAndUserRelationshipCommandRepository _commandRepository;
    private readonly IMainRoleAndUserRelationshipQueryRepository _queryRepository;
    private readonly IAppUnitOfWork _unitOfWork;

    public MainRoleAndUserRelationshipService(IMainRoleAndUserRelationshipCommandRepository commandRepository, IMainRoleAndUserRelationshipQueryRepository queryRepository, IAppUnitOfWork unitOfWork)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(MainRoleAndUserRelationship mainRoleAndUserRelationship, CancellationToken cancellationToken)
    {
        await _commandRepository.AddAsync(mainRoleAndUserRelationship, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<MainRoleAndUserRelationship> GetByIdAsync(string id, bool tracking)
        => await _queryRepository.GetByIdAsync(id, tracking);

    public async Task<MainRoleAndUserRelationship> GetByUserIdCompanyIdAndMainRoleIdAsync(string userId, string companyId, string mainRoleId, CancellationToken cancellationToken)
        => await _queryRepository.GetFirstByExpiressionAsync(p => p.UserId == userId && p.CompanyId == companyId && p.MainRoleId == mainRoleId, cancellationToken);

    public async Task<MainRoleAndUserRelationship> GetRolesByUserIdAndCompanyIdAsync(string userId, string companyId)
        => await _queryRepository.GetFirstByExpiressionAsync(p => p.UserId == userId && p.CompanyId == companyId, default);

    public async Task RemoveByIdAsync(string id)
    {
        await _commandRepository.RemoveAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }
}
