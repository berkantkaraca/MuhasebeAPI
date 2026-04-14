using MuhasebeAPI.Application.Exceptions;
using MuhasebeAPI.Application.Messaging.Command;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Domain.Entities.App;

namespace MuhasebeAPI.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.CreateMainRoleAndRoleRL;

public sealed record CreateMainRoleAndRoleRLCommandHandler : ICommandHandler<CreateMainRoleAndRoleRLCommandRequest, CreateMainRoleAndRoleRLCommandResponse>
{
    private readonly IMainRoleAndRoleRelationshipService _mainRoleAndRoleRelationshipService;

    public CreateMainRoleAndRoleRLCommandHandler(IMainRoleAndRoleRelationshipService mainRoleAndRoleRelationshipService)
    {
        _mainRoleAndRoleRelationshipService = mainRoleAndRoleRelationshipService;
    }

    public async Task<CreateMainRoleAndRoleRLCommandResponse> Handle(CreateMainRoleAndRoleRLCommandRequest request, CancellationToken cancellationToken)
    {
        MainRoleAndRoleRelationship checkRoleAndMainRoleIsRelated = await _mainRoleAndRoleRelationshipService.GetByRoleIdAndMainRoleIdAsync(request.RoleId, request.MainRoleId, cancellationToken);

        if (checkRoleAndMainRoleIsRelated != null)
            throw new ConflictException("Bu rol ilişlişi daha önce kurulmuş!");

        MainRoleAndRoleRelationship mainRoleAndRoleRelationship = new(Guid.NewGuid().ToString(), request.RoleId, request.MainRoleId);

        await _mainRoleAndRoleRelationshipService.CreateAsync(mainRoleAndRoleRelationship, cancellationToken);
        return new();
    }
}
