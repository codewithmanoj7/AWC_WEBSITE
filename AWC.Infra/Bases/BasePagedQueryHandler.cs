using AWC.Infra.Data;
using AWC.Infra.Helpers;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.Infra.Bases;

public abstract class BasePagedQueryHandler<TQuery, TBo>(CollegeContext dataAccessLayer, ILogger logger, string storedProcedureName)
    : IRequestHandler<TQuery, PaginatedQueryResult<TBo>>
    where TQuery : IRequest<PaginatedQueryResult<TBo>>
{
    protected abstract void AddParameters(DynamicParameters parameters, TQuery command);

    public async Task<PaginatedQueryResult<TBo>> Handle(TQuery request, CancellationToken cancellationToken)
    {
        try
        {
            // Validate pagination parameters (assuming TQuery has PageNumber and PageSize properties)
            if (request.GetType().GetProperty("PageNumber")?.GetValue(request) is int pageNumber && pageNumber <= 0 ||
                request.GetType().GetProperty("PageSize")?.GetValue(request) is int pageSize && pageSize <= 0)
            {
                throw new ArgumentException("PageNumber and PageSize must be greater than zero.");
            }

            var parameters = new DynamicParameters();
            AddParameters(parameters, request);

            logger.LogInformation("Executing stored procedure {StoredProcedure} with parameters: {Parameters}",
                storedProcedureName, DbUtils.GetDynamicParametersAsString(parameters));

            // Execute the stored procedure
            var result = await dataAccessLayer.ExecutePaginatedQueryAsync<TBo>(storedProcedureName, parameters);

            logger.LogInformation("Successfully fetched paginated result from {StoredProcedure}", storedProcedureName);

            return result;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while fetching paginated results using stored procedure {StoredProcedure}", storedProcedureName);
            throw;
        }
    }
}