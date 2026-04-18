using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Application.Repositories.AppDbContextRepositories.UserAndCompanyRelationshipRepositories;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Application.UnitOfWorks;
using MuhasebeAPI.Domain.Entities.App;

namespace MuhasebeAPI.Persistence.Services.AppServices;

public class UserAndCompanyRelationshipService : IUserAndCompanyRelationshipService
{
    private readonly IUserAndCompanyRelationshipCommandRepository _commandRepository;
    private readonly IUserAndCompanyRelationshipQueryRepository _queryRepository;
    private readonly IAppUnitOfWork _unitOfWork;

    public UserAndCompanyRelationshipService(IUserAndCompanyRelationshipCommandRepository commandRepository, IAppUnitOfWork unitOfWork, IUserAndCompanyRelationshipQueryRepository queryRepository)
    {
        _commandRepository = commandRepository;
        _unitOfWork = unitOfWork;
        _queryRepository = queryRepository;
    }

    public async Task CreateAsync(UserAndCompanyRelationship userAndCompanyRelationship, CancellationToken cancellationToken)
    {
        await _commandRepository.AddAsync(userAndCompanyRelationship, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<UserAndCompanyRelationship> GetByIdAsync(string id)
        => await _queryRepository.GetByIdAsync(id);

    public async Task<UserAndCompanyRelationship> GetByUserIdAndCompanyIdAsync(string userId, string companyId, CancellationToken cancellationToken)
        => await _queryRepository.GetFirstByExpiressionAsync(p => p.AppUserId == userId && p.CompanyId == companyId, cancellationToken);

    public async Task<IList<UserAndCompanyRelationship>> GetListByUserIdAsync(string userId)
        => await _queryRepository.GetWhere(p => p.AppUserId == userId).Include("Company").ToListAsync();

    public async Task RemoveByIdAsync(string id)
    {
        await _commandRepository.RemoveAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }
}
