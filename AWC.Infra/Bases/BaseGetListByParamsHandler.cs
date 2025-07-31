using AWC.Infra.Data;
using AWC.Infra.Interfaces;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.Infra.Bases
{
    public abstract class BaseGetListByParamsHandler<TQuery, TBO>(CollegeContext dataAccessLayer, ILogger logger, string storedProcedureName) : IRequestHandler<TQuery, List<TBO>>
            where TQuery : IRequest<List<TBO>>, IParameterizedQuery
    {
        public async Task<List<TBO>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var parameters = new DynamicParameters();

            // Populate parameters from the request
            foreach (var param in request.Parameters)
            {
                parameters.Add(param.Key, param.Value);
            }

            try
            {
                logger.LogInformation("Executing stored procedure: {_storedProcedureName} with parameters: {Parameters}", storedProcedureName, request.Parameters);

                var entities = await dataAccessLayer.ExecuteQueryAsync<TBO>(storedProcedureName, parameters);

                if (entities.Any())
                {
                    logger.LogInformation("Entities fetched successfully using stored procedure: {_storedProcedureName}", storedProcedureName);
                }
                else
                {
                    logger.LogWarning("No entities found using stored procedure: {_storedProcedureName}", storedProcedureName);
                }

                return entities.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while executing stored procedure: {_storedProcedureName} with parameters: {Parameters}", storedProcedureName, request.Parameters);
                throw;
            }
        }
    }

}
