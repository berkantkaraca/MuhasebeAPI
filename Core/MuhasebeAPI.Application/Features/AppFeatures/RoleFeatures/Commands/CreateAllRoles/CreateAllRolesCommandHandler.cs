using MuhasebeAPI.Application.Messaging.Command;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Domain.Entities.App.Identity;
using MuhasebeAPI.Domain.Roles;

namespace MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Commands.CreateAllRoles;

public sealed class CreateAllRolesCommandHandler : ICommandHandler<CreateAllRolesCommandRequest, CreateAllRolesCommandResponse>
{
    private readonly IRoleService _roleService;

    public CreateAllRolesCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<CreateAllRolesCommandResponse> Handle(CreateAllRolesCommandRequest request, CancellationToken cancellationToken)
    {
        IList<AppRole> originalRoleList = RoleList.GetStaticRoles();
        IList<AppRole> newRoleList = new List<AppRole>();

        foreach (var role in originalRoleList)
        {
            AppRole? checkRole = await _roleService.GetByCode(role.Code);

            if (checkRole == null) 
                newRoleList.Add(role);
        }

        await _roleService.AddRangeAsync(newRoleList);
        return new();
    }
}
