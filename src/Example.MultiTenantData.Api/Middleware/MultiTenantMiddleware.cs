using Example.MultiTenantData.Contracts;

namespace Example.MultiTenantData.Api.Middleware;

internal sealed class MultiTenantMiddleware : IMiddleware
{
    private readonly ITenantSetter _tenantSetter;

    public MultiTenantMiddleware(ITenantSetter tenantSetter)
    {
        _tenantSetter = tenantSetter;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Query.TryGetValue("tenant", out var values))
        {
            var tenant = values.FirstOrDefault();
            if (tenant != null && tenant.StartsWith("tenant"))
            {
                _tenantSetter.SetTenant(tenant);
            }
        }

        await next(context);
    }
}
