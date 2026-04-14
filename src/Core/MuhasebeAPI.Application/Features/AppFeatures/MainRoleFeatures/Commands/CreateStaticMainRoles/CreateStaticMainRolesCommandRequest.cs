using MuhasebeAPI.Application.Messaging.Command;
using MuhasebeAPI.Domain.Entities.App;

namespace MuhasebeAPI.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateStaticMainRoles;

public sealed record CreateStaticMainRolesCommandRequest(List<MainRole> MainRoles) : ICommand<CreateStaticMainRolesCommandResponse>;
