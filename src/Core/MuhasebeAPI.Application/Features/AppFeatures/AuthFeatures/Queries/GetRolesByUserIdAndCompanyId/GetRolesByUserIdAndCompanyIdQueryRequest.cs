using MuhasebeAPI.Application.Messaging.Query;

namespace MuhasebeAPI.Application.Features.AppFeatures.AuthFeatures.Queries.GetRolesByUserIdAndCompanyId;

public sealed record GetRolesByUserIdAndCompanyIdQueryRequest(
    string UserId,
    string CompanyId
): IQuery<GetRolesByUserIdAndCompanyIdQueryResponse>;
