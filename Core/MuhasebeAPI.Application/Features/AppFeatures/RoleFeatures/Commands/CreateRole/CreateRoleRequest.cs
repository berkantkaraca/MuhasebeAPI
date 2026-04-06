using MediatR;

namespace MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;

public sealed class CreateRoleRequest : IRequest<CreateRoleResponse>
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
}
