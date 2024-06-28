using System.ComponentModel.DataAnnotations;

namespace Example.MultiTenantData.DA.Entities;

public class TenantEntityBase : EntityBase
{
    [StringLength(50)]
    public string TenantId { get; set; } = null!;
}
