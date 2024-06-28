using Example.MultiTenantData.Contracts;

namespace Example.MultiTenantData.Api.Tenant;

internal sealed class TenantService : ITenantGetter, ITenantSetter
{
    private const string Unauthorised = "Unauthorised";

    public string Tenant { get; private set; } = Unauthorised;

    public void SetTenant(string tenant)
    {
        Tenant = tenant;
    }
}
