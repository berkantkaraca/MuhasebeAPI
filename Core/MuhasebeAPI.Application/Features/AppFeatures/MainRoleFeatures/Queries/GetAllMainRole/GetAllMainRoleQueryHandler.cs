using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Application.Messaging.Query;
using MuhasebeAPI.Application.Services.AppServices;

namespace MuhasebeAPI.Application.Features.AppFeatures.MainRoleFeatures.Queries.GetAllMainRole;

public sealed class GetAllMainRoleQueryHandler : IQueryHander<GetAllMainRoleQueryRequest, GetAllMainRoleQueryResponse>
{
    private readonly IMainRoleService _mainRoleService;

    public GetAllMainRoleQueryHandler(IMainRoleService mainRoleService)
    {
        _mainRoleService = mainRoleService;
    }

    public async Task<GetAllMainRoleQueryResponse> Handle(GetAllMainRoleQueryRequest request, CancellationToken cancellationToken)
    {
        return new(await _mainRoleService.GetAll().ToListAsync());
    }
}
