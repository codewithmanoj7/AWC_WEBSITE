using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities.Site;
using AWC.Infra.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Queries.News;

public class GetListByParamsQuery(string? name = null, string? description = null)
    : IRequest<List<NewsEntity>>, IParameterizedQuery
{
    public Dictionary<string, object?> Parameters { get; } = new()
    {
        { "Name", name },
        { "Description", description }
    };
}

public class GetNewssByParamsQueryHandler(CollegeContext dataAccessLayer, ILogger<GetNewssByParamsQueryHandler> logger)
    : BaseGetListByParamsHandler<GetListByParamsQuery, NewsEntity>(
        dataAccessLayer,
        logger,
        "[site].[usp_GetNewsByParam]");