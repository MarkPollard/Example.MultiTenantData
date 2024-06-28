namespace Example.MultiTenantData.Contracts;

public interface ITenantSetter
{
    void SetTenant(string tenant);
}