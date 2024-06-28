using Example.MultiTenantData.Contracts.Dto;
using Example.MultiTenantData.DA.Entities;

using Riok.Mapperly.Abstractions;

namespace Example.MultiTenantData.BusinessLogic.Mapping;

[Mapper]
public partial class SegregatedEntityMapper
{
    [MapProperty(nameof(SegregatedEntity.ReferenceEntity), nameof(SegregatedDto.Reference))]
    public partial SegregatedDto SegregatedEntityToSegregatedDto(SegregatedEntity segregatedEntity);
}