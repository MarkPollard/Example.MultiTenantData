using Example.MultiTenantData.Contracts.Dto;
using Example.MultiTenantData.DA.Entities;

using Riok.Mapperly.Abstractions;

namespace Example.MultiTenantData.BusinessLogic.Mapping;

[Mapper]
public partial class ReferenceEntityMapper
{
    public partial ReferenceDto ReferenceEntityToReferenceDto(ReferenceEntity referenceEntity);
}