using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Data;

namespace AWC.CQRS.Commands.Session
{
    public class UpsertCommand : SessionEntity, IRequest<UpsertCommandResult>
    {
    }

    public class SessionCommandHandler : BaseUpsertCommandHandler<UpsertCommand, SessionEntity>
    {
        public SessionCommandHandler(CollegeContext dataAccessLayer, ILogger<SessionCommandHandler> logger)
            : base(dataAccessLayer, logger, "[acc].[usp_InsertOrUpdateSession]")
        {
        }

        protected override void AddParameters(DynamicParameters parameters, UpsertCommand command)
        {
            parameters.Add("UserId", command.UserId);
            parameters.Add("ExpireAt", command.ExpireAt);
            parameters.Add("InsertedId", dbType: DbType.Guid, direction: ParameterDirection.Output);
        }
    }

}
