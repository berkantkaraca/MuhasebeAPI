using MuhasebeAPI.Domain.Entities.App;

namespace MuhasebeAPI.Application.Features.AppFeatures.MainRoleFeatures.Queries.GetAllMainRole;

public sealed record GetAllMainRoleQueryResponse(IList<MainRole> mainRoles);
