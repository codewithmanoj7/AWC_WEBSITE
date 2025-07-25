using AWC.Infra.Data;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.Infra.Bases
{
    public abstract class BaseUpsertCommandHandler<TCommand, TEntity>(
        CollegeContext dataAccessLayer, ILogger logger, string storedProcedureName) :
        IRequestHandler<TCommand, UpsertCommandResult>
            where TCommand : IRequest<UpsertCommandResult>
    {
        protected abstract void AddParameters(DynamicParameters parameters, TCommand command);

        public async Task<UpsertCommandResult> Handle(TCommand command, CancellationToken cancellationToken)
        {
            var parameters = new DynamicParameters();
            AddParameters(parameters, command);

            try
            {
                logger.LogInformation("Executing stored procedure: {StoredProcedureName}", storedProcedureName);

                foreach (var param in parameters.ParameterNames)
                {
                    var value = parameters.Get<object>(param);
                    logger.LogInformation($"{param} = {value}");
                }

                var result = await dataAccessLayer.ExecuteNonQueryAsync(storedProcedureName, parameters);
                Guid? insertedId = null;
                if (parameters.ParameterNames.Contains("InsertedId"))
                {
                    var raw = parameters.Get<object>("InsertedId");
                    if (raw != null && raw != DBNull.Value)
                    {
                        insertedId = (Guid)raw;
                    }
                }


                if (result > 0)
                {
                    logger.LogInformation("Entity created or updated successfully with result: {Result} using stored procedure: {StoredProcedureName}", result, storedProcedureName);
                }
                else
                {
                    logger.LogWarning("Entity creation or update failed with result: {Result} using stored procedure: {StoredProcedureName}", result, storedProcedureName);
                }


                return new UpsertCommandResult
                {
                    Result = result,
                    InsertedId = insertedId
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while saving entity using stored procedure: {StoredProcedureName}.", storedProcedureName);
                return new UpsertCommandResult { Result = 0 };
            }
        }
    }
}
