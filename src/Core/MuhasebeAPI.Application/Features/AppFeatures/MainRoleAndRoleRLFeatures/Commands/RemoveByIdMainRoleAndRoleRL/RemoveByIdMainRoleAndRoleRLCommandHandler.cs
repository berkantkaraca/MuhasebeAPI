using MuhasebeAPI.Application.Exceptions;
using MuhasebeAPI.Application.Messaging.Command;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Domain.Entities.App;

namespace MuhasebeAPI.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.RemoveByIdMainRoleAndRoleRL;

public sealed class RemoveByIdMainRoleAndRoleRLCommandHandler : ICommandHandler<RemoveByIdMainRoleAndRoleRLCommandRequest, RemoveByIdMainRoleAndRoleRLCommandResponse>
{
    private readonly IMainRoleAndRoleRelationshipService _roleRelationshipService;

    public RemoveByIdMainRoleAndRoleRLCommandHandler(IMainRoleAndRoleRelationshipService roleRelationshipService)
    {
        _roleRelationshipService = roleRelationshipService;
    }

    public async Task<RemoveByIdMainRoleAndRoleRLCommandResponse> Handle(RemoveByIdMainRoleAndRoleRLCommandRequest request, CancellationToken cancellationToken)
    {
        MainRoleAndRoleRelationship entity = await _roleRelationshipService.GetByIdAsync(request.Id);

        if (entity == null)
            throw new NotFoundException("Belirtilen Ana Rol ve Rol bağlantısı bulunamadı!");

        await _roleRelationshipService.RemoveByIdAsync(request.Id);
        return new();
    }
}
