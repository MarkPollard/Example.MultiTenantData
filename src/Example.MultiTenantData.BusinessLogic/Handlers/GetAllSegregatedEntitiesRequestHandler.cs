using Microsoft.Extensions.Logging;

using FluentResults;
using MediatR;
using PrimaryParameter.SG;

using Example.MultiTenantData.BusinessLogic.Requests;
using Example.MultiTenantData.Contracts.Dto;
using Example.MultiTenantData.DA.Entities;
using Example.MultiTenantData.DA.Queries;
using Example.MultiTenantData.BusinessLogic.Mapping;

namespace Example.MultiTenantData.BusinessLogic.Handlers;

internal sealed partial class GetAllSegregatedEntitiesRequestHandler(
    [Field(Name = "_queryRunner")] IQueryRunner<AllSegregatedQuery, IList<SegregatedEntity>> queryRunner,
    [Field(Name = "_logger")] ILogger<GetAllSegregatedEntitiesRequestHandler> logger) : IRequestHandler<GetAllSegregatedEntitiesRequest, Result<IList<SegregatedDto>>>
{
    public async Task<Result<IList<SegregatedDto>>> Handle(GetAllSegregatedEntitiesRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var dbEntities = await _queryRunner.ExecuteAsync(new AllSegregatedQuery(), cancellationToken);

            _logger.LogInformation($"{dbEntities.Count} segregated data entities to map from the db");

            var segregatedEntityMapper = new SegregatedEntityMapper();
            var segraegatedDtos = dbEntities.Select(segregatedEntityMapper.SegregatedEntityToSegregatedDto).ToList();
            return Result.Ok<IList<SegregatedDto>>(segraegatedDtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get all segregated data entities");
            return Result.Fail(ex.Message);
        }
    }
}
