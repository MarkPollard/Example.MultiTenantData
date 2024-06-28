using System.Reflection;

using Microsoft.OpenApi.Models;

using Example.MultiTenantData.Api.Middleware;
using Example.MultiTenantData.Api.Tenant;
using Example.MultiTenantData.Contracts;
using Example.MultiTenantData.DA.EF.DI;
using Example.MultiTenantData.BusinessLogic.DI;

namespace Example.MultiTenantData.Api.DI;

public static class ServicesRegistration
{
    public static IServiceCollection ConfigureApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITenantGetter, TenantService>();
        services.AddScoped<ITenantSetter>(x => (TenantService)x.GetRequiredService<ITenantGetter>());
        services.AddScoped<MultiTenantMiddleware>();
        services.AddScoped<MultiTenantClaimsMiddleware>();
        services.AddHealthChecks();
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy => { policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
        });
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.ConfigureSwaggerGenServices(configuration);
        services.ConfigureBusinessLogicServices();
        services.ConfigureDataServices(configuration);

        return services;
    }

    private static IServiceCollection ConfigureSwaggerGenServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(c =>
        {
            var apiVersion = Assembly.GetExecutingAssembly()!.GetName()!.Version!.Major;
            c.SwaggerDoc($"v{apiVersion}", new OpenApiInfo { Title = "Example Multi Tenant Data", Version = $"v{apiVersion}" });
        });

        return services;
    }
}