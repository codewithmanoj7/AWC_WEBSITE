using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Commands.PageContent
{
    public class UpsertCommand : PageContentEntity, IRequest<UpsertCommandResult>
    {
    }

    public class PageContentCommandHandler(CollegeContext dataAccessLayer, ILogger<PageContentCommandHandler> logger)
        : BaseUpsertCommandHandler<UpsertCommand, PageContentEntity>(dataAccessLayer, logger, "[site].[usp_InsertOrUpdatePageContent]")
    {
        protected override void AddParameters(DynamicParameters parameters, UpsertCommand command)
        {
            parameters.Add("Id", command.Id);
            parameters.Add("NavigationMenuId", command.NavigationMenuId);
            parameters.Add("Header", command.Header);
            parameters.Add("SubHeader", command.SubHeader);
            parameters.Add("MetaDescription", command.MetaDescription);
            parameters.Add("MetaKeywords", command.MetaKeywords);
            parameters.Add("HeroBanner", command.HeroBanner);
            parameters.Add("Paragraph", command.Paragraph);
            parameters.Add("SecondaryContent", command.SecondaryContent);
            parameters.Add("Pdf", command.Pdf);
            parameters.Add("Image", command.Image);
            parameters.Add("Gallery", command.Gallery);
            parameters.Add("VideoUrl", command.VideoUrl);
            parameters.Add("ContactInfo", command.ContactInfo);
            parameters.Add("SortOrder", command.SortOrder);
            parameters.Add("IsActive", command.IsActive);
            parameters.Add("ShowInBreadcrumb", command.ShowInBreadcrumb);
            parameters.Add("CreatedBy", command.CreatedBy);
            parameters.Add("UpdatedBy", command.UpdatedBy);
        }
    }
}