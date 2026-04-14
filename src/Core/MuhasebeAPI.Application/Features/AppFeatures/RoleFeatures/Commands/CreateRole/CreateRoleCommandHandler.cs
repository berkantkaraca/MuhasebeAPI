using MuhasebeAPI.Application.Exceptions;
using MuhasebeAPI.Application.Messaging.Command;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Domain.Entities.App.Identity;

namespace MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;

public sealed class CreateRoleCommandHandler : ICommandHandler<CreateRoleCommandRequest, CreateRoleCommandResponse>
{
    private readonly IRoleService _roleService;

    public CreateRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
    {
        AppRole? role = await _roleService.GetByCode(request.Code);

        if (role != null) 
            throw new ConflictException("Bu rol daha önce kayıt edilmiş!");

        await _roleService.AddAsync(request);
        return new();
    }
}
