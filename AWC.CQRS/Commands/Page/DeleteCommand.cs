using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Commands.Page;

public class DeleteCommand : PageEntity, IRequest<UpsertCommandResult>;

public class DeletePageCommandHandler(CollegeContext dataAccessLayer, ILogger<DeletePageCommandHandler> logger)
    : BaseUpsertCommandHandler<DeleteCommand, PageEntity>(dataAccessLayer, logger, "[site].[usp_DeletePageById]")
{
    protected override void AddParameters(DynamicParameters parameters, DeleteCommand command)
    {
        parameters.Add("Id", command.Id);
        parameters.Add("DeletedBy", command.DeletedBy);
    }
}