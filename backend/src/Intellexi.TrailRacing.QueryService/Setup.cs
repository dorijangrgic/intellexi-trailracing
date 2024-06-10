using System.Reflection;
using Intellexi.TrailRacing.QueryService.MessageHandlers;

namespace Intellexi.TrailRacing.QueryService;

public static class Setup
{
    public static IServiceCollection AddMessageHandlersFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        var messageHandlerType = typeof(IMessageHandler<>);
        var messageHandlerImplementations = assembly.GetTypes()
            .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == messageHandlerType));
        
        foreach (var implementationType in messageHandlerImplementations)
        {
            var serviceType = implementationType.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == messageHandlerType);
            services.AddScoped(serviceType, implementationType);
        }
        
        return services;
    }
}