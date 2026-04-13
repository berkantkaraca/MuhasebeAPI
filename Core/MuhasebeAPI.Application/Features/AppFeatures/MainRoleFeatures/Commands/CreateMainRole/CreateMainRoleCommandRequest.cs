using MuhasebeAPI.Application.Messaging.Command;

namespace MuhasebeAPI.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;

public sealed record CreateMainRoleCommandRequest(
    string Title,
    string CompanyId = null
) : ICommand<CreateMainRoleCommandResponse>;
