using MuhasebeAPI.Application.Exceptions;
using MuhasebeAPI.Application.Messaging.Command;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Domain.Entities.App.Identity;

namespace MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;

public sealed class DeleteRoleCommandHandler : ICommandHandler<DeleteRoleCommandRequest, DeleteRoleCommandResponse>
{

    private readonly IRoleService _roleService;

    public DeleteRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
    {
        AppRole? role = await _roleService.GetById(request.Id);

        if (role == null) 
            throw new NotFoundException("Role bulunamadı!");

        await _roleService.DeleteAsync(role);

        return new();
    }
}
