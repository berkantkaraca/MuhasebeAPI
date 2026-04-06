using MuhasebeAPI.Application.Messaging.Command;

namespace MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;

public sealed record DeleteRoleCommandRequest(
        string Id
) : ICommand<DeleteRoleCommandResponse>;
