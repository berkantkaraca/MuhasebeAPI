using MuhasebeAPI.Application.Messaging.Command;

namespace MuhasebeAPI.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.CreateMainRoleAndRoleRL;

public sealed record CreateMainRoleAndRoleRLCommandRequest(
    string RoleId,
    string MainRoleId
) : ICommand<CreateMainRoleAndRoleRLCommandResponse>;

