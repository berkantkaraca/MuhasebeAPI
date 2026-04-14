using MuhasebeAPI.Application.Messaging.Command;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Domain.Entities.App.Identity;
using MuhasebeAPI.Domain.Roles;

namespace MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Commands.CreateStaticRoles;

public sealed class CreateStaticRolesCommandHandler : ICommandHandler<CreateStaticRolesCommandRequest, CreateStaticRolesCommandResponse>
{
    private readonly IRoleService _roleService;

    public CreateStaticRolesCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<CreateStaticRolesCommandResponse> Handle(CreateStaticRolesCommandRequest request, CancellationToken cancellationToken)
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
