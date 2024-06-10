using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Intellexi.TrailRacing.Application;

public static class Setup
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options => options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}