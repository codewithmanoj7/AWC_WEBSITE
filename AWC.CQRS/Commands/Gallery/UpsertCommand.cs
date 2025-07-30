using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities.Site;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Commands.Gallery;

public class UpsertCommand : GalleryEntity, IRequest<UpsertCommandResult>;

public class GalleryCommandHandler(CollegeContext dataAccessLayer, ILogger<GalleryCommandHandler> logger)
    : BaseUpsertCommandHandler<UpsertCommand, GalleryEntity>(dataAccessLayer, logger, "[site].[usp_InsertOrUpdateGallery]")
{
    protected override void AddParameters(DynamicParameters parameters, UpsertCommand command)
    {
        parameters.Add("Id", command.Id);
        parameters.Add("Name", command.Name);
        parameters.Add("Image", command.Image);
        parameters.Add("CreatedBy", command.CreatedBy);
        parameters.Add("UpdatedBy", command.UpdatedBy);
    }
}