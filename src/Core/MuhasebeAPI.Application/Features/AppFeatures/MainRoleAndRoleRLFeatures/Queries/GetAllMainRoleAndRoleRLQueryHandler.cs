using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Application.Messaging.Query;
using MuhasebeAPI.Application.Services.AppServices;

namespace MuhasebeAPI.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Queries;

public sealed class GetAllMainRoleAndRoleRLQueryHandler : IQueryHander<GetAllMainRoleAndRoleRLQueryRequest, GetAllMainRoleAndRoleRLQueryResponse>
{
    private readonly IMainRoleAndRoleRelationshipService _roleRelationshipService;

    public GetAllMainRoleAndRoleRLQueryHandler(IMainRoleAndRoleRelationshipService roleRelationshipService)
    {
        _roleRelationshipService = roleRelationshipService;
    }

    public async Task<GetAllMainRoleAndRoleRLQueryResponse> Handle(GetAllMainRoleAndRoleRLQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await _roleRelationshipService
                                    .GetAll()
                                    .Include("AppRole")
                                    .Include("MainRole")
                                    .ToListAsync();
        return new(result);
    }
}
