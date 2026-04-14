using MuhasebeAPI.Domain.Entities.App.Identity;

namespace MuhasebeAPI.Application.Abstractions;

public interface IJwtProvider
{
    Task<string> CreateTokenAsync(AppUser user, List<string> roles);
}
