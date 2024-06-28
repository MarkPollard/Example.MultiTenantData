using System.Security.Claims;

using Example.MultiTenantData.Contracts;

namespace Example.MultiTenantData.Api.Middleware;

internal sealed class MultiTenantClaimsMiddleware : IMiddleware
{
    public const string TenantClaimType = "http://schemas.microsoft.com/identity/claims/tenantid";

    private readonly ITenantSetter _tenantSetter;

    public MultiTenantClaimsMiddleware(ITenantSetter tenantSetter)
    {
        _tenantSetter = tenantSetter;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var claimsIdentity = (ClaimsIdentity)context.Request.HttpContext.User.Identity;
        var tenantClaim = claimsIdentity?.Claims.FirstOrDefault(c => c.Type.Equals(TenantClaimType));
        if (tenantClaim != null)
        {
            _tenantSetter.SetTenant(tenantClaim.Value);
        }

        await next(context);
    }
}
