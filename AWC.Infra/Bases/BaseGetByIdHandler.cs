using AWC.Infra.Data;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.Infra.Bases
{
    public abstract class BaseGetByIdHandler<TQuery, TBO>(CollegeContext dataAccessLayer, ILogger logger, string storedProcedureName, string parameterKey) : IRequestHandler<TQuery, TBO>
        where TQuery : IRequest<TBO>, IBaseIdentifiable
    {
        public async Task<TBO> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var parameters = new DynamicParameters();
            parameters.Add(parameterKey, request.Id); // Access 'Id' through the interface

            try
            {
                logger.LogInformation("Fetching entity with ID: {EntityId} using stored procedure: {_storedProcedureName}", request.Id, storedProcedureName);

                var entities = await dataAccessLayer.ExecuteQueryAsync<TBO>(storedProcedureName, parameters);

                var entity = entities.FirstOrDefault();
                if (entity != null)
                {
                    logger.LogInformation("Entity with ID: {EntityId} fetched successfully.", request.Id);
                }
                else
                {
                    logger.LogWarning("No entity found with ID: {EntityId}.", request.Id);
                }
#nullable disable
                return entity;
#nullable enable
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while fetching the entity with ID: {EntityId} using stored procedure: {_storedProcedureName}", request.Id, storedProcedureName);
                throw;
            }
        }
    }

}
