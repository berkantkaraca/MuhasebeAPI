
using MuhasebeAPI.Domain.Entities.App;

namespace MuhasebeAPI.Application.Services.AppServices;

public interface IMainRoleAndRoleRelationshipService
{
    Task CreateAsync(MainRoleAndRoleRelationship mainRoleAndRoleRelationship, CancellationToken cancellationToken);
    Task UpdateAsync(MainRoleAndRoleRelationship mainRoleAndRoleRelationship);
    Task RemoveByIdAsync(string id);
    IQueryable<MainRoleAndRoleRelationship> GetAll();
    Task<MainRoleAndRoleRelationship> GetByIdAsync(string id);
    Task<MainRoleAndRoleRelationship> GetByRoleIdAndMainRoleIdAsync(string roleId, string mainRoleId, CancellationToken cancellationToken = default);
    Task<IList<MainRoleAndRoleRelationship>> GetListByMainRoleIdForGetRolesAsync(string id);
}