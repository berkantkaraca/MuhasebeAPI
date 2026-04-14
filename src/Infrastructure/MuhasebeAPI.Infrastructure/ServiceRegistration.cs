using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using MuhasebeAPI.Application.Abstractions;
using MuhasebeAPI.Infrastructure.Authentication;
using MuhasebeAPI.Infrastructure.OptionsSetup;

namespace MuhasebeAPI.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtProvider, JwtProvider>();

        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<JwtBearerOptionsSetup>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();
    }
}
