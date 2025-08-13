using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Commands.PageContent
{
    // Delete Command for Page Content
    public class DeleteCommand : PageContentEntity, IRequest<UpsertCommandResult>
    {
    }

    public class DeletePageContentCommandHandler(CollegeContext dataAccessLayer, ILogger<DeletePageContentCommandHandler> logger)
        : BaseUpsertCommandHandler<DeleteCommand, PageContentEntity>(dataAccessLayer, logger, "[site].[usp_DeletePageContentById]")
    {
        protected override void AddParameters(DynamicParameters parameters, DeleteCommand command)
        {
            parameters.Add("Id", command.Id);
            parameters.Add("DeletedBy", command.DeletedBy);
        }
    }
}