using MuhasebeAPI.Application.Messaging.Query;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Domain.Entities.App.Identity;

namespace MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;

public sealed class GetAllRolesQueryHandler : IQueryHander<GetAllRolesQueryRequest, GetAllRolesQueryResponse>
{
    private readonly IRoleService _roleService;

    public GetAllRolesQueryHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<GetAllRolesQueryResponse> Handle(GetAllRolesQueryRequest request, CancellationToken cancellationToken)
    {
        IList<AppRole> roles = await _roleService.GetAllRolesAsync();
        return new GetAllRolesQueryResponse(Roles: roles);
    }
}
