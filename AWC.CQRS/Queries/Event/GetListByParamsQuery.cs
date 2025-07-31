using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities.Site;
using AWC.Infra.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Queries.Event;

public class GetListByParamsQuery(DateTime? date = null, string? name = null, DateTime? fromDate = null, DateTime? endDate = null)
    : IRequest<List<EventEntity>>, IParameterizedQuery
{
    public Dictionary<string, object?> Parameters { get; } = new()
    {
        { "Date", date },
        { "Name", name },
        { "FromDate", fromDate },
        { "EndDate", endDate }
    };
}

public class GetEventsByParamsQueryHandler(CollegeContext dataAccessLayer, ILogger<GetEventsByParamsQueryHandler> logger)
    : BaseGetListByParamsHandler<GetListByParamsQuery, EventEntity>(
        dataAccessLayer,
        logger,
        "[site].[usp_GetEventByParam]");