using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Domain.Entities.App.Identity;
using MuhasebeAPI.Persistence.Contexts;
using MuhasebeAPI.Persistence.Mapping;
using MuhasebeAPI.Persistence.Services.AppServices;

namespace MuhasebeAPI.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

        services.AddIdentity<AppUser, AppRole>()
            .AddEntityFrameworkStores<AppDbContext>();

        services.AddAutoMapper(cfg =>
        {
            cfg.LicenseKey = configuration.GetSection("AutoMapperApiKey").Value;
        }, typeof(MappingProfile));

        services.AddScoped<ICompanyService, CompanyService>();
    }
}
