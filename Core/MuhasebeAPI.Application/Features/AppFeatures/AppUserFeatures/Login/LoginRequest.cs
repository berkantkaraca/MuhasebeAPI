using MediatR;

namespace MuhasebeAPI.Application.Features.AppFeatures.AppUserFeatures.Login;

public sealed class LoginRequest : IRequest<LoginResponse>
{
    public string EmailOrUserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}
