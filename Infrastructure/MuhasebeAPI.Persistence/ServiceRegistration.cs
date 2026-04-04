using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MuhasebeAPI.Application;
using MuhasebeAPI.Application.Repositories.UCAFRepositories;
using MuhasebeAPI.Application.Services;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Application.Services.CompanyServices;
using MuhasebeAPI.Domain.Entities.App.Identity;
using MuhasebeAPI.Persistence.Contexts;
using MuhasebeAPI.Persistence.Mapping;
using MuhasebeAPI.Persistence.Repositories.UCAFRepositories;
using MuhasebeAPI.Persistence.Services;
using MuhasebeAPI.Persistence.Services.AppServices;
using MuhasebeAPI.Persistence.Services.CompanyServices;

namespace MuhasebeAPI.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

        services.AddIdentity<AppUser, AppRole>()
            .AddEntityFrameworkStores<AppDbContext>();

        services.AddAutoMapper(cfg =>
        {
            cfg.LicenseKey = configuration.GetSection("AutoMapperApiKey").Value;
        }, typeof(MappingProfile));

        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IUCAFService, UCAFService>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IContextService, ContextService>();

        services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
        services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();
    }
}
