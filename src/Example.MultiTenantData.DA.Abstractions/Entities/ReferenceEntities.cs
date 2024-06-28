namespace Example.MultiTenantData.DA.Entities;

public static class ReferenceEntities
{
    public static IEnumerable<ReferenceEntity> GetAll()
    {
        return
        [
            new() { Id = new Guid("e065b699-0e9c-493a-80dd-c8efec0eb2ca"), Name = "Reference Item 1" },
            new() { Id = new Guid("1429f2ed-05ee-465c-a37a-e77537d98b21"), Name = "Reference Item 2" }
        ];
    }
}
