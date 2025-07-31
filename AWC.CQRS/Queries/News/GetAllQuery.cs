using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities.Site;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Queries.News;

public class GetAllQuery : IRequest<IList<NewsEntity>>;

public class GetAllNewssQueryHandler(CollegeContext dataAccessLayer, ILogger<GetAllNewssQueryHandler> logger)
    : BaseGetAllQueryHandler<GetAllQuery, NewsEntity>(dataAccessLayer, logger, "[site].[usp_GetAllNews]");