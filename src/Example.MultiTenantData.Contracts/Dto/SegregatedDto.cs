namespace Example.MultiTenantData.Contracts.Dto;

public class SegregatedDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Date { get; set; }

    public ReferenceDto Reference { get; set; } = null!;

    public string TenantId { get; set; } = null!;
}
