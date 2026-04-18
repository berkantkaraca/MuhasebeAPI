using MuhasebeAPI.Domain.Entities.App;

namespace MuhasebeAPI.Application.Services.AppServices;

public interface IUserAndCompanyRelationshipService
{
    Task CreateAsync(UserAndCompanyRelationship userAndCompanyRelationship, CancellationToken cancellationToken);
    Task RemoveByIdAsync(string id);
    Task<UserAndCompanyRelationship> GetByIdAsync(string id);
    Task<UserAndCompanyRelationship> GetByUserIdAndCompanyIdAsync(string userId, string companyId, CancellationToken cancellationToken);
}
