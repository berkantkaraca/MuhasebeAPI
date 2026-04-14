using MuhasebeAPI.Application.Messaging.Command;

namespace MuhasebeAPI.Application.Features.AppFeatures.MainRoleFeatures.Commands.RemoveByIdMainRole;

public sealed record RemoveByIdMainRoleCommandRequest(string Id) : ICommand<RemoveByIdMainRoleCommandResponse>;
