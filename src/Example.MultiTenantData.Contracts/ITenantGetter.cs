namespace Example.MultiTenantData.Contracts;

public interface ITenantGetter
{
    string Tenant { get; }
}