using MuhasebeAPI.Application.Exceptions;
using MuhasebeAPI.Application.Messaging.Command;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Domain.Entities.App;

namespace MuhasebeAPI.Application.Features.AppFeatures.MainRoleFeatures.Commands.UpdateMainRole;

public sealed class UpdateMainRoleCommandHandler : ICommandHandler<UpdateMainRoleCommandRequest, UpdateMainRoleCommandResponse>
{
    private readonly IMainRoleService _mainRoleService;

    public UpdateMainRoleCommandHandler(IMainRoleService mainRoleService)
    {
        _mainRoleService = mainRoleService;
    }

    public async Task<UpdateMainRoleCommandResponse> Handle(UpdateMainRoleCommandRequest request, CancellationToken cancellationToken)
    {
        MainRole mainRole = await _mainRoleService.GetByIdAsync(request.Id);

        if (mainRole == null)
            throw new NotFoundException("Bu ana rol bulunamadı!");

        if (mainRole.Title == request.Title)
            throw new ConflictException("Güncellemeye çalıştığınız ana rol adı eski adı ile aynı!");

        if (mainRole.Title != request.Title)
        {
            MainRole checkMainRoleTitle = await _mainRoleService.GetByTitleAndCompanyIdAsync(request.Title, mainRole.CompanyId, cancellationToken);

            if (checkMainRoleTitle != null) 
                throw new ConflictException("Bu rol adı daha önce kullanılmış!");
        }

        mainRole.Title = request.Title;
        await _mainRoleService.UpdateAsync(mainRole);
        return new();
    }
}
