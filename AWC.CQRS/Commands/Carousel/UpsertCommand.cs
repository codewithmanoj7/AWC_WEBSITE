using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities.Site;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Commands.Carousel
{
    public class UpsertCommand : CarouselEntity, IRequest<UpsertCommandResult>;

    public class CarouselCommandHandler(CollegeContext dataAccessLayer, ILogger<CarouselCommandHandler> logger)
        : BaseUpsertCommandHandler<UpsertCommand, CarouselEntity>(dataAccessLayer, logger, "[site].[usp_InsertOrUpdateCarousel]")
    {
        protected override void AddParameters(DynamicParameters parameters, UpsertCommand command)
        {
            parameters.Add("Id", command.Id);
            parameters.Add("Description", command.Description);
            parameters.Add("Image", command.Image);
            parameters.Add("CreatedBy", command.CreatedBy);
            parameters.Add("UpdatedBy", command.UpdatedBy);
        }
    }
}
