using FluentResults;
using MediatR;

using Example.MultiTenantData.Contracts.Dto;

namespace Example.MultiTenantData.BusinessLogic.Requests;

public sealed class GetAllSegregatedEntitiesRequest : IRequest<Result<IList<SegregatedDto>>>
{
}