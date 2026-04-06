using MediatR;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Domain.Entities.App.Identity;

namespace MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;

public sealed class CreateRoleHandler : IRequestHandler<CreateRoleRequest, CreateRoleResponse>
{
    private readonly IRoleService _roleService;

    public CreateRoleHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<CreateRoleResponse> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
    {
        AppRole role = await _roleService.GetByCode(request.Code);

        if (role != null) 
            throw new Exception("Bu rol daha önce kayıt edilmiş!");

        await _roleService.AddAsync(request);
        return new();
    }
}
