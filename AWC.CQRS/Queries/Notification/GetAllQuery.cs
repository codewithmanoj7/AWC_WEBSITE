using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities.Site;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Queries.Notification;

public class GetAllQuery : IRequest<IList<NotificationEntity>>;

public class GetAllNotificationQueryHandler(CollegeContext dataAccessLayer, ILogger<GetAllNotificationQueryHandler> logger)
    : BaseGetAllQueryHandler<GetAllQuery, NotificationEntity>(dataAccessLayer, logger, "[site].[usp_GetAllNotification]");