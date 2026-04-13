using MuhasebeAPI.Application.Exceptions;
using MuhasebeAPI.Application.Messaging.Command;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Domain.Entities.App;

namespace MuhasebeAPI.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;

public sealed class CreateMainRoleCommandHandler : ICommandHandler<CreateMainRoleCommandRequest, CreateMainRoleCommandResponse>
{
    private readonly IMainRoleService _mainRoleService;

    public CreateMainRoleCommandHandler(IMainRoleService mainRoleService)
    {
        _mainRoleService = mainRoleService;
    }

    public async Task<CreateMainRoleCommandResponse> Handle(CreateMainRoleCommandRequest request, CancellationToken cancellationToken)
    {
        MainRole checkMainRoleTitle = await _mainRoleService.GetByTitleAndCompanyIdAsync(request.Title, request.CompanyId, cancellationToken);

        if (checkMainRoleTitle != null)
            throw new ConflictException("Bu rol daha önce kaydedilmiş!");

        MainRole mainRole = new(
            Guid.NewGuid().ToString(),
            request.Title,
            request.CompanyId != null ? false : true,
            request.CompanyId
        );

        await _mainRoleService.CreateAsync(mainRole, cancellationToken);

        return new();
    }
}
