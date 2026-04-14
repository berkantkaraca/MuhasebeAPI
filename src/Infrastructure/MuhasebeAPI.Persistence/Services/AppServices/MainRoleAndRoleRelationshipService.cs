using MuhasebeAPI.Application.Repositories.AppDbContextRepositories.MainRoleAndRoleRelationshipRepositories;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Application.UnitOfWorks;
using MuhasebeAPI.Domain.Entities.App;

namespace MuhasebeAPI.Persistence.Services.AppServices;

public class MainRoleAndRoleRelationshipService : IMainRoleAndRoleRelationshipService
{
    private readonly IMainRoleAndRoleRelationshipCommandRepository _commandRepository;
    private readonly IMainRoleAndRoleRelationshipQueryRepository _queryRepository;
    private readonly IAppUnitOfWork _unitOfWork;

    public MainRoleAndRoleRelationshipService(IMainRoleAndRoleRelationshipCommandRepository commandRepository, IMainRoleAndRoleRelationshipQueryRepository queryRepository, IAppUnitOfWork unitOfWork)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(MainRoleAndRoleRelationship mainRoleAndRoleRelationship, CancellationToken cancellationToken)
    {
        await _commandRepository.AddAsync(mainRoleAndRoleRelationship, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<MainRoleAndRoleRelationship> GetAll()
        =>_queryRepository.GetAll();

    public async Task<MainRoleAndRoleRelationship> GetByIdAsync(string id)
        => await _queryRepository.GetByIdAsync(id);

    public async Task<MainRoleAndRoleRelationship> GetByRoleIdAndMainRoleIdAsync(string roleId, string mainRoleId, CancellationToken cancellationToken = default)
        => await _queryRepository.GetFirstByExpiressionAsync(p => p.RoleId == roleId && p.MainRoleId == mainRoleId, cancellationToken);

    public async Task RemoveByIdAsync(string id)
    {
        await _commandRepository.RemoveAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(MainRoleAndRoleRelationship mainRoleAndRoleRelationship)
    {
        _commandRepository.Update(mainRoleAndRoleRelationship);
        await _unitOfWork.SaveChangesAsync();
    }
}
