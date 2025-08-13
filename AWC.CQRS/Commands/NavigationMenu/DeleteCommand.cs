using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Commands.NavigationMenu
{
    public class DeleteCommand : NavigationMenuEntity, IRequest<UpsertCommandResult>
    {
    }

    public class DeleteNavigationMenuCommandHandler(CollegeContext dataAccessLayer, ILogger<DeleteNavigationMenuCommandHandler> logger)
        : BaseUpsertCommandHandler<DeleteCommand, NavigationMenuEntity>(dataAccessLayer, logger, "[site].[usp_DeleteNavigationMenuById]")
    {
        protected override void AddParameters(DynamicParameters parameters, DeleteCommand command)
        {
            parameters.Add("Id", command.Id);
            parameters.Add("DeletedBy", command.DeletedBy);
        }
    }
}