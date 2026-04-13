using MuhasebeAPI.Application.Messaging.Command;

namespace MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Commands.CreateStaticRoles;

public sealed record CreateStaticRolesCommandRequest() : ICommand<CreateStaticRolesCommandResponse>;
