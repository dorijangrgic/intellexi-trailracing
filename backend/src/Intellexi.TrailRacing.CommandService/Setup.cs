using System.Text.Json.Serialization;
using Asp.Versioning;
using Intellexi.TrailRacing.Application.Common;
using Intellexi.TrailRacing.CommandService.ExceptionHandlers;
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
    
    public static IServiceCollection AddErrorHandling(this IServiceCollection services)
    {
        services.AddExceptionHandler<BaseServiceExceptionHandler>();
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        return services;
    }

    public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder)
    {
        builder.UseExceptionHandler();

        return builder;
    }
    
    public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        return services;
    }
}