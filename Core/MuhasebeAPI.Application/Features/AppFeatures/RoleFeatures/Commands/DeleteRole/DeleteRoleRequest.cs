using MediatR;

namespace MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;

public sealed class DeleteRoleRequest : IRequest<DeleteRoleResponse>
{
    public string Id { get; set; }

    public DeleteRoleRequest(string id)
    {
        Id = id;
    }
}
