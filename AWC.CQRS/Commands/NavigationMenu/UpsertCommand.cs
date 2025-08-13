using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Commands.NavigationMenu
{
    public class UpsertCommand : NavigationMenuEntity, IRequest<UpsertCommandResult>
    {
    }

    public class NavigationMenuCommandHandler(CollegeContext dataAccessLayer, ILogger<NavigationMenuCommandHandler> logger)
        : BaseUpsertCommandHandler<UpsertCommand, NavigationMenuEntity>(dataAccessLayer, logger, "[site].[usp_InsertOrUpdateNavigationMenu]")
    {
        protected override void AddParameters(DynamicParameters parameters, UpsertCommand command)
        {
            parameters.Add("Id", command.Id);
            parameters.Add("ParentId", command.ParentId);
            parameters.Add("Url", command.Url);
            parameters.Add("Name", command.Name);
            parameters.Add("Description", command.Description);
            parameters.Add("SortOrder", command.SortOrder);
            parameters.Add("Level", command.Level);
            parameters.Add("IsActive", command.IsActive);
            parameters.Add("IsExternal", command.IsExternal);
            parameters.Add("Icon", command.Icon);
            parameters.Add("CssClass", command.CssClass);
            parameters.Add("CreatedBy", command.CreatedBy);

            // Ensure UpdatedBy is never null - use CreatedBy as fallback if needed
            parameters.Add("UpdatedBy", command.UpdatedBy ?? command.CreatedBy);
        }
    }
}