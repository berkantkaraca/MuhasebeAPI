using MuhasebeAPI.Application.Messaging.Command;

namespace MuhasebeAPI.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.CreateMainRoleAndUserRL;

public sealed record CreateMainRoleAndUserRLCommandRequest(
    string UserId,
    string MainRoleId,
    string CompanyId
) : ICommand<CreateMainRoleAndUserRLCommandResponse>;
