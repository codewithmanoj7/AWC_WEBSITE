using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities.Site;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Commands.Event;
public class UpsertCommand : EventEntity, IRequest<UpsertCommandResult>;

public class EventCommandHandler(CollegeContext dataAccessLayer, ILogger<EventCommandHandler> logger)
    : BaseUpsertCommandHandler<UpsertCommand, EventEntity>(dataAccessLayer, logger, "[site].[usp_InsertOrUpdateEvent]")
{
    protected override void AddParameters(DynamicParameters parameters, UpsertCommand command)
    {
        parameters.Add("Id", command.Id);
        parameters.Add("Date", command.Date);
        parameters.Add("EndDate", command.EndDate);
        parameters.Add("Name", command.Name);
        parameters.Add("Location", command.Location);
        parameters.Add("StartTime", command.StartTime);
        parameters.Add("EndTime", command.EndTime);
        parameters.Add("Description", command.Description);
        parameters.Add("MaxAttendees", command.MaxAttendees);
        parameters.Add("RegistrationRequired", command.RegistrationRequired);
        parameters.Add("IsActive", command.IsActive);
        parameters.Add("ImageUrl", command.ImageUrl);
        parameters.Add("ExternalUrl", command.ExternalUrl);
        parameters.Add("CreatedBy", command.CreatedBy);
        parameters.Add("UpdatedBy", command.UpdatedBy);
    }
}