using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities.Site;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Commands.Event;

public class DeleteCommand : EventEntity, IRequest<UpsertCommandResult>;

public class DeleteEventCommandHandler(CollegeContext dataAccessLayer, ILogger<DeleteEventCommandHandler> logger)
    : BaseUpsertCommandHandler<DeleteCommand, EventEntity>(dataAccessLayer, logger, "[site].[usp_DeleteEventById]")
{
    protected override void AddParameters(DynamicParameters parameters, DeleteCommand command)
    {
        parameters.Add("Id", command.Id);
        parameters.Add("DeletedBy", command.DeletedBy);
    }
}