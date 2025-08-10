using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities.Site;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Commands.Notification;

public class UpsertCommand : NotificationEntity, IRequest<UpsertCommandResult>;

public class NotificationCommandHandler(CollegeContext dataAccessLayer, ILogger<NotificationCommandHandler> logger)
    : BaseUpsertCommandHandler<UpsertCommand, NotificationEntity>(dataAccessLayer, logger, "[site].[usp_InsertOrUpdateNotification]")
{
    protected override void AddParameters(DynamicParameters parameters, UpsertCommand command)
    {
        parameters.Add("Id", command.Id);
        parameters.Add("Name", command.Name);
        parameters.Add("Description", command.Description);
        parameters.Add("Image", command.Image);
        parameters.Add("CreatedBy", command.CreatedBy);
        parameters.Add("UpdatedBy", command.UpdatedBy);
    }
}