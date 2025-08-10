using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities.Site;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Queries.Notification;

public class GetByIdQuery : NotificationEntity, IRequest<NotificationEntity>, IBaseIdentifiable;

public class GetNewsByIdQueryHandler(CollegeContext dataAccessLayer, ILogger<GetNewsByIdQueryHandler> logger)
    : BaseGetByIdHandler<GetByIdQuery, NotificationEntity>(dataAccessLayer, logger, "[site].[usp_GetNotificationById]", "Id");