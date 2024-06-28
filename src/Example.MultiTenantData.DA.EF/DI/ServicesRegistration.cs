using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Example.MultiTenantData.Contracts;
using Example.MultiTenantData.DA.EF.Queries;
using Example.MultiTenantData.DA.Entities;
using Example.MultiTenantData.DA.Queries;

namespace Example.MultiTenantData.DA.EF.DI;

public static class ServicesRegistration
{
    private const string EFMigrationsHistoryTableName = "__EFMigrationsHistory";

    public static IServiceCollection ConfigureDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<MtDbContext>((serviceProvider, options) =>
        {
            var tenant = serviceProvider.GetService<ITenantGetter>()!.Tenant;
            options.UseSqlServer(configuration.GetConnectionString(tenant),
                                 x => x.MigrationsHistoryTable(EFMigrationsHistoryTableName, MtDbContext.SchemaName));
        }, ServiceLifetime.Scoped);
        services.AddScoped<IQueryRunner<AllSegregatedQuery, IList<SegregatedEntity>>, AllSegregatedQueryRunner>();
        return services;
    }
    public static IServiceCollection ConfigureDataServicesDeployment(this IServiceCollection services, string migrationsAssemblyName)
    {
        services.AddDbContextFactory<MtDbContext>((serviceProvider, options) =>
        {
            options.UseSqlServer(serviceProvider.GetService<IConfiguration>()!.GetConnectionString("MigrationConnection"),
                                 x => x.MigrationsHistoryTable(EFMigrationsHistoryTableName, MtDbContext.SchemaName)
                                       .MigrationsAssembly(migrationsAssemblyName));
        });
        return services;
    }
}
