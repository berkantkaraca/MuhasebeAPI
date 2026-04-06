using Microsoft.AspNetCore.Identity;

namespace MuhasebeAPI.Domain.Entities.App.Identity;

public sealed class AppRole : IdentityRole<string>
{
    public string? Code { get; set; }
}
