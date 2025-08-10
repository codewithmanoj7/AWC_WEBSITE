using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Commands.Page;

public class UpsertCommand : PageEntity, IRequest<UpsertCommandResult>
{
}

public class PageCommandHandler(CollegeContext dataAccessLayer, ILogger<PageCommandHandler> logger)
    : BaseUpsertCommandHandler<UpsertCommand, PageEntity>(dataAccessLayer, logger, "[site].[usp_InsertOrUpdatePage]")
{
    protected override void AddParameters(DynamicParameters parameters, UpsertCommand command)
    {
        parameters.Add("Id", command.Id);
        parameters.Add("Url", command.Url);
        parameters.Add("Name", command.Name);
        parameters.Add("Description", command.Description);
        parameters.Add("Pdf", command.Pdf);
        parameters.Add("CreatedBy", command.CreatedBy);
        parameters.Add("UpdatedBy", command.UpdatedBy);
    }
}