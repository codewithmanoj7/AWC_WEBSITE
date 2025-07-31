using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities.Site;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Commands.News;

public class DeleteCommand : NewsEntity, IRequest<UpsertCommandResult>;

public class DeleteNewsCommandHandler(CollegeContext dataAccessLayer, ILogger<DeleteNewsCommandHandler> logger)
    : BaseUpsertCommandHandler<DeleteCommand, NewsEntity>(dataAccessLayer, logger, "[site].[usp_DeleteNewsById]")
{
    protected override void AddParameters(DynamicParameters parameters, DeleteCommand command)
    {
        parameters.Add("Id", command.Id);
        parameters.Add("DeletedBy", command.DeletedBy);
    }
}