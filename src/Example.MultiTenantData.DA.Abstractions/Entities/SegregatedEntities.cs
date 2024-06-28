namespace Example.MultiTenantData.DA.Entities;

public static class SegregatedEntities
{
    public static IEnumerable<SegregatedEntity> GetDefault()
    {
        return
        [
            new() { Id = new Guid("408ecb1e-fed7-4b37-977a-97f1709bb3f5"), Name = "Segregated Entity 1", Date = DateTime.Parse("2024-01-01 00:00:00"), ReferenceEntityId = new Guid("e065b699-0e9c-493a-80dd-c8efec0eb2ca"), TenantId = "tenanta" },
            new() { Id = new Guid("816d9651-cb1f-44d3-adb7-d8372451bbb7"), Name = "Segregated Entity 2", Date = DateTime.Parse("2024-01-01 00:00:00"), ReferenceEntityId = new Guid("1429f2ed-05ee-465c-a37a-e77537d98b21"), TenantId = "tenanta" },
            new() { Id = new Guid("9d6bffc6-7afa-43f7-8d40-1fd8679fe046"), Name = "Segregated Entity 3", Date = DateTime.Parse("2024-01-01 00:00:00"), ReferenceEntityId = new Guid("e065b699-0e9c-493a-80dd-c8efec0eb2ca"), TenantId = "tenantb" },
            new() { Id = new Guid("361976b4-2542-49c6-988f-49de24b64ac9"), Name = "Segregated Entity 4", Date = DateTime.Parse("2024-01-01 00:00:00"), ReferenceEntityId = new Guid("1429f2ed-05ee-465c-a37a-e77537d98b21"), TenantId = "tenantc" }
        ];
    }
}
