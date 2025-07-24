using AWC.Infra.Data;
using AWC.Infra.Helpers;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.Infra.Bases
{
    public abstract class BaseDeleteCommandHandler<TCommand, TEntity>(
    CollegeContext dataAccessLayer,
    ILogger logger,
    string storedProcedureName,
    string parameterName) : IRequestHandler<TCommand, int>
    where TCommand : IRequest<int>, IBaseIdentifiable
    {
        private readonly CollegeContext _dataAccessLayer = dataAccessLayer;
        private readonly ILogger _logger = logger;
        private readonly string _storedProcedureName = storedProcedureName;
        private readonly string _parameterName = parameterName;

        public async Task<int> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var parameters = new DynamicParameters();
            parameters.Add(_parameterName, request.Id);

            try
            {
                _logger.LogInformation("Starting deletion with ID: {Id} using stored procedure: {StoredProcedureName} with parameters: {Parameters}",
                    request.Id, _storedProcedureName, DbUtils.GetDynamicParametersAsString(parameters));

                int result = await _dataAccessLayer.ExecuteNonQueryAsync(_storedProcedureName, parameters);

                if (result > 0)
                {
                    _logger.LogInformation("Entity with ID: {Id} deleted successfully.", request.Id);
                }
                else
                {
                    _logger.LogWarning("No entity found with ID: {Id}.", request.Id);
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting entity with ID: {Id} using stored procedure: {StoredProcedureName}.", request.Id, _storedProcedureName);
                throw;
            }
        }
    }

}
