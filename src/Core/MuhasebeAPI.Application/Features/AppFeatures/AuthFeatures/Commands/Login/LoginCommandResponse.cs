using MuhasebeAPI.Application.Dtos;

namespace MuhasebeAPI.Application.Features.AppFeatures.AuthFeatures.Commands.Login;

public sealed record LoginCommandResponse(
    TokenRefreshTokenDto Token,
    string Email,
    string UserId,
    string NameLastName,
    IList<CompanyDto> Companies,
    CompanyDto Company
);
