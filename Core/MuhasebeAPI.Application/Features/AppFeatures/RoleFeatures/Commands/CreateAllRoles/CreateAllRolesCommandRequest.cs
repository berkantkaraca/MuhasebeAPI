using MuhasebeAPI.Application.Messaging.Command;

namespace MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Commands.CreateAllRoles;

public sealed record CreateAllRolesCommandRequest() : ICommand<CreateAllRolesCommandResponse>;
