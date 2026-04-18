using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MuhasebeAPI.Application.Repositories.AppDbContextRepositories.CompanyRepositories;
using MuhasebeAPI.Application.Repositories.AppDbContextRepositories.MainRoleRepositories;
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
using MuhasebeAPI.Application.Repositories.AppDbContextRepositories.MainRoleAndRoleRelationshipRepositories;
using MuhasebeAPI.Persistence.Repositories.AppDbContextRepositories.MainRoleAndRoleRelationshipRepositories;
using MuhasebeAPI.Application.Repositories.AppDbContextRepositories.MainRoleAndUserRelationshipRepositories;
using MuhasebeAPI.Persistence.Repositories.AppDbContextRepositories.MainRoleAndUserRelationshipRepositories;
using MuhasebeAPI.Application.Repositories.AppDbContextRepositories.UserAndCompanyRelationshipRepositories;
using MuhasebeAPI.Persistence.Repositories.AppDbContextRepositories.UserAndCompanyRelationshipRepositories;
//UsingSpot

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
        //CompanyServiceDISpot

        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IMainRoleService, MainRoleService>();
        services.AddScoped<IMainRoleAndRoleRelationshipService, MainRoleAndRoleRelationshipService>();
        services.AddScoped<IMainRoleAndUserRelationshipService, MainRoleAndUserRelationshipService>();
        services.AddScoped<IUserAndCompanyRelationshipService, UserAndCompanyRelationshipService>();
        services.AddScoped<IAuthService, AuthService>();
        //AppServiceDISpot

        services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
        services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();
        //CompanyRepositoryDISpot

        services.AddScoped<ICompanyCommandRepository, CompanyCommandRepository>();
        services.AddScoped<ICompanyQueryRepository, CompanyQueryRepository>();
        services.AddScoped<IMainRoleCommandRepository, MainRoleCommandRepository>();
        services.AddScoped<IMainRoleQueryRepository, MainRoleQueryRepository>();
        services.AddScoped<IMainRoleAndRoleRelationshipCommandRepository, MainRoleAndRoleRelationshipCommandRepository>();
        services.AddScoped<IMainRoleAndRoleRelationshipQueryRepository, MainRoleAndRoleRelationshipQueryRepository>();
        services.AddScoped<IMainRoleAndUserRelationshipCommandRepository, MainRoleAndUserRelationshipCommandRepository>();
        services.AddScoped<IMainRoleAndUserRelationshipQueryRepository, MainRoleAndUserRelationshipQueryRepository>();
        services.AddScoped<IUserAndCompanyRelationshipCommandRepository, UserAndCompanyRelationshipCommandRepository>();
        services.AddScoped<IUserAndCompanyRelationshipQueryRepository, UserAndCompanyRelationshipQueryRepository>();
        //AppRepositoryDISpot
    }
}
