using Intellexi.TrailRacing.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Intellexi.TrailRacing.RabbitMq;

public static class Setup
{
    public static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMessageSender, MessageSender>();

        services.Configure<RabbitMqConfig>(configuration.GetSection(RabbitMqConfig.Section));
        
        JsonConvert.DefaultSettings = () => new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };

        return services;
    }
}