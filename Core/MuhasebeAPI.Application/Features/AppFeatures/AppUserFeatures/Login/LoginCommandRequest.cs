using MuhasebeAPI.Application.Messaging.Command;

namespace MuhasebeAPI.Application.Features.AppFeatures.AppUserFeatures.Login;

public sealed record LoginCommandRequest(
    string EmailOrUserName,
    string Password
) : ICommand<LoginCommandResponse>;
