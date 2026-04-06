
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Domain.Entities.App.Identity;

namespace MuhasebeAPI.Persistence.Services.AppServices;

public class RoleService : IRoleService
{
    private readonly RoleManager<AppRole> _roleManager;
    private readonly IMapper _mapper;

    public RoleService(RoleManager<AppRole> roleManager, IMapper mapper)
    {
        _roleManager = roleManager;
        _mapper = mapper;
    }

    public async Task AddAsync(CreateRoleCommandRequest request)
    {
        AppRole role = _mapper.Map<AppRole>(request);
        role.Id = Guid.NewGuid().ToString();
        await _roleManager.CreateAsync(role);
    }

    public async Task DeleteAsync(AppRole appRole)
    {
        await _roleManager.DeleteAsync(appRole);
    }

    public async Task<IList<AppRole>> GetAllRolesAsync()
    {
        return await _roleManager.Roles.ToListAsync();
    }

    public async Task<AppRole?> GetByCode(string code)
    {
        AppRole? role = await _roleManager.Roles.FirstOrDefaultAsync(p => p.Code == code);
        return role;
    }

    public async Task<AppRole?> GetById(string id)
    {
        AppRole? role = await _roleManager.FindByIdAsync(id);
        return role;
    }

    public async Task UpdateAsync(AppRole appRole)
    {
        await _roleManager.UpdateAsync(appRole);
    }
}
