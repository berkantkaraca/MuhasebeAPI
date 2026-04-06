using MuhasebeAPI.Application.Messaging.Command;

namespace MuhasebeAPI.Application.Features.AppFeatures.AppUserFeatures.Commands.Login;

public sealed record LoginCommandRequest(
    string EmailOrUserName,
    string Password
) : ICommand<LoginCommandResponse>;
