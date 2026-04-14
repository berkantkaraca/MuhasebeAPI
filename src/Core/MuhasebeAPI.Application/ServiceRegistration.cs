using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MuhasebeAPI.Application.Behavior;

namespace MuhasebeAPI.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ServiceRegistration).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), (typeof(ValidationBehavior<,>)));
        services.AddValidatorsFromAssembly(typeof(ServiceRegistration).Assembly);
    }
}
