using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Queries.Page;

public class GetByIdQuery : PageEntity, IRequest<PageEntity>, IBaseIdentifiable;

public class GetPageByIdQueryHandler(CollegeContext dataAccessLayer, ILogger<GetPageByIdQueryHandler> logger)
    : BaseGetByIdHandler<GetByIdQuery, PageEntity>(dataAccessLayer, logger, "[site].[usp_GetPageById]", "Id");