using MuhasebeAPI.Application.Messaging.Command;
using MuhasebeAPI.Application.Services.AppServices;

namespace MuhasebeAPI.Application.Features.AppFeatures.MainRoleFeatures.Commands.RemoveByIdMainRole;

public sealed class RemoveByIdMainRoleCommandHandler : ICommandHandler<RemoveByIdMainRoleCommandRequest, RemoveByIdMainRoleCommandResponse>
{
    private readonly IMainRoleService _mainRoleService;

    public RemoveByIdMainRoleCommandHandler(IMainRoleService mainRoleService)
    {
        _mainRoleService = mainRoleService;
    }

    public async Task<RemoveByIdMainRoleCommandResponse> Handle(RemoveByIdMainRoleCommandRequest request, CancellationToken cancellationToken)
    {
        await _mainRoleService.RemoveByIdAsync(request.Id);
        return new();
    }
}
