using MuhasebeAPI.Domain.Entities.App.Identity;

namespace MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;

public sealed class GetAllRolesResponse
{
    public IList<AppRole> Roles { get; set; } = new List<AppRole>();
}
