using MuhasebeAPI.Application.Messaging.Query;
using MuhasebeAPI.Application.Services.AppServices;

namespace MuhasebeAPI.Application.Features.AppFeatures.AuthFeatures.Queries.GetRolesByUserIdAndCompanyId;

public sealed class GetRolesByUserIdAndCompanyIdQueryHandler : IQueryHander<GetRolesByUserIdAndCompanyIdQueryRequest, GetRolesByUserIdAndCompanyIdQueryResponse>
{
    private readonly IAuthService _authService;

    public GetRolesByUserIdAndCompanyIdQueryHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<GetRolesByUserIdAndCompanyIdQueryResponse> Handle(GetRolesByUserIdAndCompanyIdQueryRequest request, CancellationToken cancellationToken)
    {
        IList<string> roles = await _authService.GetRolesByUserIdAndCompanyIdAsync(request.UserId, request.CompanyId);
        return new(roles);
    }
}
