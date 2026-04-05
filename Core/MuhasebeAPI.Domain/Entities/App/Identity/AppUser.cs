using Microsoft.AspNetCore.Identity;

namespace MuhasebeAPI.Domain.Entities.App.Identity;

public sealed class AppUser : IdentityUser<string>
{
    public string NameLastName { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public DateTime RefreshTokenExpires { get; set; }
}
