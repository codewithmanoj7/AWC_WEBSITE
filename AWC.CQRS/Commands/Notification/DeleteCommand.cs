using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities.Site;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Commands.Notification;

public class DeleteCommand : NotificationEntity, IRequest<UpsertCommandResult>;

public class DeleteNotificationCommandHandler(CollegeContext dataAccessLayer, ILogger<DeleteNotificationCommandHandler> logger)
    : BaseUpsertCommandHandler<DeleteCommand, NotificationEntity>(dataAccessLayer, logger, "[site].[usp_DeleteNotificationById]")
{
    protected override void AddParameters(DynamicParameters parameters, DeleteCommand command)
    {
        parameters.Add("Id", command.Id);
        parameters.Add("DeletedBy", command.DeletedBy);
    }
}