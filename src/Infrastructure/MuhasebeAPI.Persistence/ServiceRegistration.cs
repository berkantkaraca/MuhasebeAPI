using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MuhasebeAPI.Application.Repositories.AppDbContextRepositories.CompanyRepositories;
using MuhasebeAPI.Application.Repositories.AppDbContextRepositories.MainRoleReporistories;
using MuhasebeAPI.Application.Repositories.CompanyDbContextRepositories.UCAFRepositories;
using MuhasebeAPI.Application.Services;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Application.Services.CompanyServices;
using MuhasebeAPI.Application.UnitOfWorks;
using MuhasebeAPI.Domain.Entities.App.Identity;
using MuhasebeAPI.Persistence.Contexts;
using MuhasebeAPI.Persistence.Mapping;
using MuhasebeAPI.Persistence.Repositories.AppDbContextRepositories.CompanyRepositories;
using MuhasebeAPI.Persistence.Repositories.AppDbContextRepositories.MainRoleRepositories;
using MuhasebeAPI.Persistence.Repositories.CompanyDbContextRepositories.UCAFRepositories;
using MuhasebeAPI.Persistence.Services;
using MuhasebeAPI.Persistence.Services.AppServices;
using MuhasebeAPI.Persistence.Services.CompanyServices;
using MuhasebeAPI.Persistence.UnitOfWorks;

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

        services.AddScoped<ICompanyDbUnitOfWork, CompanyDbUnitOfWork>();
        services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();
        services.AddScoped<IContextService, ContextService>();

        services.AddScoped<IUCAFService, UCAFService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IMainRoleService, MainRoleService>();

        services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
        services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();
        services.AddScoped<ICompanyCommandRepository, CompanyCommandRepository>();
        services.AddScoped<ICompanyQueryRepository, CompanyQueryRepository>();
        services.AddScoped<IMainRoleCommandRepository, MainRoleCommandRepository>();
        services.AddScoped<IMainRoleQueryRepository, MainRoleQueryRepository>();
    }
}
