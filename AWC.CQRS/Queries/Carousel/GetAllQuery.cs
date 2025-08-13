using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities.Site;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Queries.Carousel;

public class GetAllQuery : IRequest<IList<CarouselEntity>>;

public class GetAllCarouselQueryHandler(CollegeContext dataAccessLayer, ILogger<GetAllCarouselQueryHandler> logger)
    : BaseGetAllQueryHandler<GetAllQuery, CarouselEntity>(dataAccessLayer, logger, "[site].[usp_GetAllCarousel]");