using MuhasebeAPI.Domain.Entities.App;

namespace MuhasebeAPI.Application.Services.AppServices;

public interface IMainRoleService
{
    IQueryable<MainRole> GetAll();
    Task<MainRole> GetByIdAsync(string id);
    Task<MainRole> GetByTitleAndCompanyIdAsync(string title, string companyId, CancellationToken cancellationToken);
    Task CreateAsync(MainRole mainRole, CancellationToken cancellationToken);
    Task CreateRangeAsync(List<MainRole> newMainRoles, CancellationToken cancellationToken);
    Task UpdateAsync(MainRole mainRole);
    Task RemoveByIdAsync(string id);
}
