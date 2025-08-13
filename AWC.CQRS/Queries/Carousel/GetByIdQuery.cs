using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities.Site;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Queries.Carousel;

public class GetByIdQuery : CarouselEntity, IRequest<CarouselEntity>, IBaseIdentifiable;

public class GetCarouselByIdQueryHandler(CollegeContext dataAccessLayer, ILogger<GetCarouselByIdQueryHandler> logger)
    : BaseGetByIdHandler<GetByIdQuery, CarouselEntity>(dataAccessLayer, logger, "[site].[usp_GetCarouselById]", "Id");