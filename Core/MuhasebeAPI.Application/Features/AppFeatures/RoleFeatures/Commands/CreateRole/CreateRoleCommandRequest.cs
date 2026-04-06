using MuhasebeAPI.Application.Messaging.Command;

namespace MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;

public sealed record CreateRoleCommandRequest(
    string Code,
    string Name
) : ICommand<CreateRoleCommandResponse>;