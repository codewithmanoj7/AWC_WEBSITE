using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities.Site;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Commands.Carousel
{
    public class DeleteCommand : CarouselEntity, IRequest<UpsertCommandResult>;

    public class DeleteCarouselCommandHandler(CollegeContext dataAccessLayer, ILogger<DeleteCarouselCommandHandler> logger)
        : BaseUpsertCommandHandler<DeleteCommand, CarouselEntity>(dataAccessLayer, logger, "[site].[usp_DeleteCarouselById]")
    {
        protected override void AddParameters(DynamicParameters parameters, DeleteCommand command)
        {
            parameters.Add("Id", command.Id);
            parameters.Add("DeletedBy", command.DeletedBy);
        }
    }
}
