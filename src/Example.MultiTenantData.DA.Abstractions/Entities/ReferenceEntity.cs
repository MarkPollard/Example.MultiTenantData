namespace Example.MultiTenantData.DA.Entities;

public class ReferenceEntity : EntityBase
{
    public virtual string Name { get; set; } = null!;

    public IList<SegregatedEntity> SegregatedEntities { get; set; } = new List<SegregatedEntity>();
}
