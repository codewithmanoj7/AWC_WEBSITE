using AWC.Infra.Data;
using AWC.Infra.Interfaces;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.Infra.Bases
{
    public abstract class BaseGetByParamsHandler<TQuery, TBO>(CollegeContext dataAccessLayer, ILogger logger, string storedProcedureName) : IRequestHandler<TQuery, TBO>
       where TQuery : IRequest<TBO>?, IParameterizedQuery?
    {
        private readonly CollegeContext _dataAccessLayer = dataAccessLayer;
        private readonly ILogger _logger = logger;
        private readonly string _storedProcedureName = storedProcedureName;

        public async Task<TBO> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var parameters = new DynamicParameters();

            // Populate parameters from the request
            foreach (var param in request.Parameters)
            {
                parameters.Add(param.Key, param.Value);
            }

            try
            {
                _logger.LogInformation("Executing stored procedure: {_storedProcedureName} with parameters: {Parameters}", _storedProcedureName, request.Parameters);

                //var entities = await _dataAccessLayer.ExecuteQueryAsync<TBO>(_storedProcedureName, parameters);
                var entities = await _dataAccessLayer.ExecuteQuerySingleOrDefaultAsync<TBO>(_storedProcedureName, parameters);
                // var entity = entities.FirstOrDefault();
                //if (entity != null)
                //{
                //    _logger.LogInformation("Entity fetched successfully using stored procedure: {_storedProcedureName}", _storedProcedureName);
                //}
                //else
                //{
                //    _logger.LogWarning("No entity found using stored procedure: {_storedProcedureName}", _storedProcedureName);
                //}
                return entities;
                //return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while executing stored procedure: {_storedProcedureName} with parameters: {Parameters}", _storedProcedureName, request.Parameters);
                throw;
            }
        }
    }

}
