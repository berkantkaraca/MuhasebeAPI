using MuhasebeAPI.Domain.Entities.App.Identity;

namespace MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;

public sealed record GetAllRolesQueryResponse(IList<AppRole> Roles);
