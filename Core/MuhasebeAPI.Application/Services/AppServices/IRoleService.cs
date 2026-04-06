using MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using MuhasebeAPI.Domain.Entities.App.Identity;

namespace MuhasebeAPI.Application.Services.AppServices;

public interface IRoleService
{
    Task AddAsync(CreateRoleCommandRequest request);
    Task AddRangeAsync(IEnumerable<AppRole> roles);
    Task UpdateAsync(AppRole appRole);
    Task DeleteAsync(AppRole appRole);
    Task<IList<AppRole>> GetAllRolesAsync();
    Task<AppRole?> GetById(string id);
    Task<AppRole?> GetByCode(string code);
}
