using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities.Site;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Commands.Gallery;

public class DeleteCommand : GalleryEntity, IRequest<UpsertCommandResult>;

public class DeleteGalleryCommandHandler(CollegeContext dataAccessLayer, ILogger<DeleteGalleryCommandHandler> logger)
    : BaseUpsertCommandHandler<DeleteCommand, GalleryEntity>(dataAccessLayer, logger, "[site].[usp_DeleteGalleryById]")
{
    protected override void AddParameters(DynamicParameters parameters, DeleteCommand command)
    {
        parameters.Add("Id", command.Id);
        parameters.Add("DeletedBy", command.DeletedBy);
    }
}