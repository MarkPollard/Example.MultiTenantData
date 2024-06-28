using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

namespace Example.MultiTenantData.BusinessLogic.DI;

public static class ServicesRegistration
{
    public static IServiceCollection ConfigureBusinessLogicServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}
