using MediatR;

namespace MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;

public sealed class UpdateRoleRequest : IRequest<UpdateRoleResponse>
{
    public string Id { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
}
