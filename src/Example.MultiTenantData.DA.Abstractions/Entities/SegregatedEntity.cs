namespace Example.MultiTenantData.DA.Entities;

public class SegregatedEntity : TenantEntityBase
{
    public virtual string Name { get; set; } = null!;

    public virtual DateTime Date { get; set; }

    public virtual Guid ReferenceEntityId { get; set; }

    public virtual ReferenceEntity ReferenceEntity { get; set; } = null!;
}
