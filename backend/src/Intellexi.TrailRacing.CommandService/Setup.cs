using System.Text.Json.Serialization;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Intellexi.TrailRacing.CommandService;

public static class Setup
{
    public static IServiceCollection AddWebApi(this IServiceCollection services)
    {
        services
            .ConfigureApiVersioning()
            .AddHttpContextAccessor()
            .AddRouting(options =>
            {
                options.LowercaseUrls = true;
            })
            .AddControllers(options =>
            {
                options.UseDefaultMvcOptions();
            })
            .AddJsonOptions(options =>
            {
                options.UseDefaultJsonOptions();
            });
        
        services.AddProblemDetails();
        
        return services;
    }
    
    private static IServiceCollection ConfigureApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        return services;
    }

    private static MvcOptions UseDefaultMvcOptions(this MvcOptions options)
    {
        options.Conventions.Add(new KebabRoutingConvention());
        return options;
    }

    private static JsonOptions UseDefaultJsonOptions(this JsonOptions options)
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        return options;
    }
}