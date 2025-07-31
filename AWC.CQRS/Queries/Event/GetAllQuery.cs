using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities.Site;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Queries.Event;

public class GetAllQuery : IRequest<IList<EventEntity>>;

public class GetAllEventsQueryHandler(CollegeContext dataAccessLayer, ILogger<GetAllEventsQueryHandler> logger)
    : BaseGetAllQueryHandler<GetAllQuery, EventEntity>(dataAccessLayer, logger, "[site].[usp_GetAllEvents]");