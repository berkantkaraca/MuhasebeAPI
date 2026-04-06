using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MuhasebeAPI.Domain.Abstractions;
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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Ignore<IdentityUserLogin<string>>();
        builder.Ignore<IdentityUserRole<string>>();
        builder.Ignore<IdentityUserClaim<string>>();
        builder.Ignore<IdentityUserToken<string>>();
        builder.Ignore<IdentityRoleClaim<string>>();

        builder.Entity<AppRole>().HasData(
            new AppRole
            {
                Id = "9E89E949-4A5A-4E4A-9B67-53E1ACB3C8A1",
                Code = "UCAF.Create",
                Name = "Hesap Planı Kayıt Ekleme",
                NormalizedName = "HESAP PLANI KAYIT EKLEME",
                ConcurrencyStamp = "D3A5D5A2-A0E8-4A69-BD5B-6F26E0E8B611"
            },
            new AppRole
            {
                Id = "B7B067AA-3D3A-4A16-B4EA-0B6C5E8EC6F2",
                Code = "UCAF.Update",
                Name = "Hesap Planı Kayıt Güncelleme",
                NormalizedName = "HESAP PLANI KAYIT GUNCELLEME",
                ConcurrencyStamp = "8E944A99-6F47-4D4D-9E9F-0AA5F08C3D9E"
            },
            new AppRole
            {
                Id = "B7B067AA-3D3A-4A16-B4EA-0DKFJSDKFLSKF",
                Code = "UCAF.Read",
                Name = "Hesap Planı Kayıt Görüntüleme",
                NormalizedName = "HESAP PLANI KAYIT GORUNTULEME",
                ConcurrencyStamp = "8E944A99-6F47-4D4D-9E9F-0AA5F08C3D9E"
            },
            new AppRole
            {
                Id = "B7B067AA-3D3A-4A16-B4EA-KSFJKLDSJFLDKD",
                Code = "UCAF.Balance",
                Name = "Hesap Planı Bakiye Görüntüleme",
                NormalizedName = "HESAP PLANI BAKIYE GORUNTULEME",
                ConcurrencyStamp = "8E944A99-6F47-4D4D-9E9F-0AA5F08C3D9E"
            }
        );
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var datas = ChangeTracker.Entries<BaseEntity>();

        foreach (var data in datas)
        {
            _ = data.State switch
            {
                EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                EntityState.Modified => data.Entity.UpdateDate = DateTime.UtcNow,
                _ => DateTime.UtcNow
            };
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder();

            var connectionString = configuration
                .GetConnectionString("SqlServer");

            optionsBuilder.UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
