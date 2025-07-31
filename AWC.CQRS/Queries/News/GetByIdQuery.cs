using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities.Site;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Queries.News;

public class GetByIdQuery : NewsEntity, IRequest<NewsEntity>, IBaseIdentifiable;

public class GetNewsByIdQueryHandler(CollegeContext dataAccessLayer, ILogger<GetNewsByIdQueryHandler> logger)
    : BaseGetByIdHandler<GetByIdQuery, NewsEntity>(dataAccessLayer, logger, "[site].[usp_GetNewsById]", "Id");