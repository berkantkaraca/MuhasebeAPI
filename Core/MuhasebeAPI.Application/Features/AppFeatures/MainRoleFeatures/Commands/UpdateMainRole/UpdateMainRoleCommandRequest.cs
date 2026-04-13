using MuhasebeAPI.Application.Messaging.Command;

namespace MuhasebeAPI.Application.Features.AppFeatures.MainRoleFeatures.Commands.UpdateMainRole;

public sealed record UpdateMainRoleCommandRequest(
    string Id,
    string Title
) : ICommand<UpdateMainRoleCommandResponse>;
