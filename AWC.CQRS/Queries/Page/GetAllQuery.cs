using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Queries.Page;

public class GetAllQuery : IRequest<IList<PageEntity>> { }

public class GetAllPagesQueryHandler(CollegeContext dataAccessLayer, ILogger<GetAllPagesQueryHandler> logger)
    : BaseGetAllQueryHandler<GetAllQuery, PageEntity>(dataAccessLayer, logger, "[site].[usp_GetAllPages]");