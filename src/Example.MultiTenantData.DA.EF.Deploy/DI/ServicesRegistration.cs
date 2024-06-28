using Example.MultiTenantData.DA.EF.DI;

namespace Example.MultiTenantData.DA.EF.Deploy.DI;

public static class ServicesRegistration
{
    public static IServiceCollection ConfigureApiServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.ConfigureDataServicesDeployment(typeof(ServicesRegistration).Assembly.FullName!);

        return services;
    }
}
