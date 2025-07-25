using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Commands.User
{
    public class DeleteCommand : SessionEntity, IRequest<UpsertCommandResult>
    {
    }

    public class DeleteCommandHandler(CollegeContext dataAccessLayer, ILogger<DeleteCommandHandler> logger)
       : BaseUpsertCommandHandler<DeleteCommand, UserEntity>(dataAccessLayer, logger, "[acc].[usp_DeleteUserById]")
    {
        protected override void AddParameters(DynamicParameters parameters, DeleteCommand command)
        {
            parameters.Add("Id", command.Id);
            parameters.Add("DeletedBy", command.DeletedBy);
        }
    }
}
