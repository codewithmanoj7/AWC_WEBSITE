using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities.Site;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Queries.Event;

public class GetByIdQuery : EventEntity, IRequest<EventEntity>, IBaseIdentifiable;

public class GetEventByIdQueryHandler(CollegeContext dataAccessLayer, ILogger<GetEventByIdQueryHandler> logger)
    : BaseGetByIdHandler<GetByIdQuery, EventEntity>(dataAccessLayer, logger, "[site].[usp_GetEventById]", "Id");