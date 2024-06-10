using Intellexi.TrailRacing.Application.Services;
using Intellexi.TrailRacing.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Intellexi.TrailRacing.Persistence;

public static class Setup
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TrailRacingDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(AppDefaults.Persistence.ConnectionString));
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            options.UseSnakeCaseNamingConvention();
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        return services;
    }
}