using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Domain.Entities.App;
using MuhasebeAPI.Domain.Entities.App.Identity;

namespace MuhasebeAPI.Persistence.Services.AppServices;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IUserAndCompanyRelationshipService _companyRelationService;
    private readonly IMainRoleAndUserRelationshipService _mainRoleAndUserRelationshipService;
    private readonly IMainRoleAndRoleRelationshipService _mainRoleAndRoleRelationshipService;

    public AuthService(UserManager<AppUser> userManager, IUserAndCompanyRelationshipService companyRelationService, IMainRoleAndUserRelationshipService mainRoleAndUserRelationshipService, IMainRoleAndRoleRelationshipService mainRoleAndRoleRelationshipService)
    {
        _userManager = userManager;
        _companyRelationService = companyRelationService;
        _mainRoleAndUserRelationshipService = mainRoleAndUserRelationshipService;
        _mainRoleAndRoleRelationshipService = mainRoleAndRoleRelationshipService;
    }

    public async Task<bool> CheckPasswordAsync(AppUser user, string password)
        => await _userManager.CheckPasswordAsync(user, password);

    public async Task<AppUser> GetByEmailOrUserNameAsync(string emailOrUserName)
        => await _userManager.Users.Where(p => p.Email == emailOrUserName || p.UserName == emailOrUserName).FirstOrDefaultAsync();

    public async Task<IList<UserAndCompanyRelationship>> GetCompanyListByUserIdAsync(string userId)
        => await _companyRelationService.GetListByUserIdAsync(userId);

    public async Task<IList<string>> GetRolesByUserIdAndCompanyIdAsync(string userId, string companyId)
    {
        MainRoleAndUserRelationship mainRoleAndUserRelationship = await _mainRoleAndUserRelationshipService.GetRolesByUserIdAndCompanyIdAsync(userId, companyId);
        IList<MainRoleAndRoleRelationship> getMainRole = await _mainRoleAndRoleRelationshipService.GetListByMainRoleIdForGetRolesAsync(mainRoleAndUserRelationship.MainRoleId);

        IList<string> roles = getMainRole.Select(s => s.AppRole.Name).ToList();
        return roles;
    }
}
