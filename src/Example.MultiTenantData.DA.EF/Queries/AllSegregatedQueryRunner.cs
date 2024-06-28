using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Example.MultiTenantData.DA.Entities;
using Example.MultiTenantData.DA.Queries;

namespace Example.MultiTenantData.DA.EF.Queries;

internal sealed class AllSegregatedQueryRunner : IQueryRunner<AllSegregatedQuery, IList<SegregatedEntity>>
{
    private readonly MtDbContext _dbContext;
    private readonly ILogger<AllSegregatedQueryRunner> _logger;

    public AllSegregatedQueryRunner(MtDbContext dbContext, ILogger<AllSegregatedQueryRunner> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<IList<SegregatedEntity>> ExecuteAsync(AllSegregatedQuery query, CancellationToken token)
    {
        var dbData = await _dbContext.SegregatedEntities
                                    .Include(d => d.ReferenceEntity)
                                    .ToListAsync();

        _logger.LogInformation($"{dbData.Count} segraegated data entities to map from the db");

        return dbData;
    }
}