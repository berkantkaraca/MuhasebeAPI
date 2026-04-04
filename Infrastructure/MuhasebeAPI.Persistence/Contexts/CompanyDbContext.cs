using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MuhasebeAPI.Domain.Abstractions;
using MuhasebeAPI.Domain.Entities.App;

namespace MuhasebeAPI.Persistence.Contexts;

public sealed class CompanyDbContext : DbContext
{
    private string ConnectionString = "";

    public CompanyDbContext(Company? company = null)
    {
        if (company != null)
        {
            if (company.UserId == "")
                ConnectionString = $"" +
                    $"Data Source={company.ServerName};" +
                    $"Initial Catalog={company.DatabaseName};" +
                    $"Integrated Security=True;" +
                    $"Connect Timeout=30;" +
                    $"Encrypt=False;" +
                    $"TrustServerCertificate=False;" +
                    $"ApplicationIntent=ReadWrite;" +
                    $"MultiSubnetFailover=False";
            else
                ConnectionString = $"" +
                    $"Data Source={company.ServerName};" +
                    $"Initial Catalog={company.DatabaseName};" +
                    $"User Id={company.UserId};" +
                    $"Password={company.Password};" +
                    $"Integrated Security=True;" +
                    $"Connect Timeout=30;" +
                    $"Encrypt=False;" +
                    $"TrustServerCertificate=False;" +
                    $"ApplicationIntent=ReadWrite;" +
                    $"MultiSubnetFailover=False";
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ServiceRegistration).Assembly);

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

    public class CompanyDbContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
    {
        public CompanyDbContext CreateDbContext(string[] args)
        {
            return new CompanyDbContext();
        }
    }
}
