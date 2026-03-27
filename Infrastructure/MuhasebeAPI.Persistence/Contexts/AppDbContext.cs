using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Domain.Entities.App;
using MuhasebeAPI.Domain.Entities.App.Identity;

namespace MuhasebeAPI.Persistence.Contexts;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<UserAndCompanyRelationship> UserAndCompanyRelationships { get; set; }
}
