namespace MuhasebeAPI.Application.Dtos;

public sealed record TokenRefreshTokenDto(
    string Token,
    string RefreshToken,
    DateTime RefreshTokenExpires
);
