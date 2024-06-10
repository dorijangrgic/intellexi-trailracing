using System.Reflection;
using FluentValidation;
using Intellexi.TrailRacing.Application.Common;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Intellexi.TrailRacing.Application;

public static class Setup
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services
            .AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            })
            .AddRequestValidationBehaviour();

        return services;
    }

    private static IServiceCollection AddRequestValidationBehaviour(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehaviour<,>));

        return services;
    }
    
    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}