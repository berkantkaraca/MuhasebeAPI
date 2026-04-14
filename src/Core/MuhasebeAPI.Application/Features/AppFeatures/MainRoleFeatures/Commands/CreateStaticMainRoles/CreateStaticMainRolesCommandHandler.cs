using MuhasebeAPI.Application.Messaging.Command;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Domain.Entities.App;
using MuhasebeAPI.Domain.Roles;

namespace MuhasebeAPI.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateStaticMainRoles;

public sealed class CreateStaticMainRolesCommandHandler : ICommandHandler<CreateStaticMainRolesCommandRequest, CreateStaticMainRolesCommandResponse>
{
    private readonly IMainRoleService _mainRoleService;

    public CreateStaticMainRolesCommandHandler(IMainRoleService mainRoleService)
    {
        _mainRoleService = mainRoleService;
    }

    public async Task<CreateStaticMainRolesCommandResponse> Handle(CreateStaticMainRolesCommandRequest request, CancellationToken cancellationToken)
    {
        List<MainRole> mainRoles = RoleList.GetStaticMainRoles();
        List<MainRole> newMainRoles= new List<MainRole>();

        foreach (var mainRole in mainRoles)
        {
            MainRole checkMainRole = await _mainRoleService.GetByTitleAndCompanyIdAsync(mainRole.Title, mainRole.CompanyId, cancellationToken);

            if (checkMainRole == null) 
                newMainRoles.Add(mainRole);
        }

        await _mainRoleService.CreateRangeAsync(newMainRoles, cancellationToken);
        return new();
    }
}
