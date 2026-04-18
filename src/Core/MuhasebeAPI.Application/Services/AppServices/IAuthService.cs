using MuhasebeAPI.Domain.Entities.App;
using MuhasebeAPI.Domain.Entities.App.Identity;

namespace MuhasebeAPI.Application.Services.AppServices;

public interface IAuthService
{
    Task<AppUser> GetByEmailOrUserNameAsync(string emailOrUserName);
    Task<bool> CheckPasswordAsync(AppUser user, string password);
    Task<IList<UserAndCompanyRelationship>> GetCompanyListByUserIdAsync(string userId);
    Task<IList<string>> GetRolesByUserIdAndCompanyIdAsync(string userId, string companyId);
}
