using AWC.Infra.Data;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.Infra.Bases
{
    public abstract class BaseGetAllQueryHandler<TQuery, TBO>(CollegeContext dataAccessLayer, ILogger logger, string storedProcedureName) : IRequestHandler<TQuery, IList<TBO>>
            where TQuery : IRequest<IList<TBO>>
    {
        public async Task<IList<TBO>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var entityName = typeof(TBO).Name.ToLowerInvariant();
                logger.LogInformation($"Fetching all {entityName}s from the database using stored procedure: {storedProcedureName}");

                var entities = await dataAccessLayer.ExecuteQueryAsync<TBO>(storedProcedureName);

                if (entities.Any())
                {
                    logger.LogInformation("{EntityCount} {EntityName}s fetched successfully.", entities.Count(), entityName);
                }
                else
                {
                    logger.LogWarning("No {EntityName}s found in the database.", entityName);
                }

                return entities.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while fetching all {EntityName}s using stored procedure: {_storedProcedureName}", typeof(TBO).Name.ToLowerInvariant(), storedProcedureName);
                throw;
            }
        }
    }

}
