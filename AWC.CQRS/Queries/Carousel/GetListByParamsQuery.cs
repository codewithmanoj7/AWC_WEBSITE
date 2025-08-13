using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities.Site;
using AWC.Infra.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Queries.Carousel;

public class GetListByParamsQuery(string? name = null, string? description = null)
    : IRequest<List<CarouselEntity>>, IParameterizedQuery
{
    public Dictionary<string, object?> Parameters { get; } = new()
    {
        { "Name", name },
        { "Description", description }
    };
}

public class GetCarouselByParamsQueryHandler(CollegeContext dataAccessLayer, ILogger<GetCarouselByParamsQueryHandler> logger)
    : BaseGetListByParamsHandler<GetListByParamsQuery, CarouselEntity>(
        dataAccessLayer,
        logger,
        "[site].[usp_GetCarouselByParam]");