using MuhasebeAPI.Application.Dtos;
using MuhasebeAPI.Domain.Entities.App.Identity;

namespace MuhasebeAPI.Application.Abstractions;

public interface IJwtProvider
{
    Task<TokenRefreshTokenDto> CreateTokenAsync(AppUser user);
}
