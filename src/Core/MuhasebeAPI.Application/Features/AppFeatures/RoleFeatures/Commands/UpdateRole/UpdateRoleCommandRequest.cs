using MuhasebeAPI.Application.Messaging.Command;

namespace MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;

public sealed record UpdateRoleCommandRequest(
    string Id,
    string Code,
    string Name
) : ICommand<UpdateRoleCommandResponse>;
