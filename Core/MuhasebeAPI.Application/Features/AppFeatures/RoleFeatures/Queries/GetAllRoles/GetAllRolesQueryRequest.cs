using MuhasebeAPI.Application.Messaging.Query;

namespace MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;

public sealed record GetAllRolesQueryRequest() : IQuery<GetAllRolesQueryResponse>;
