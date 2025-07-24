using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Queries.Session;

public class GetByIdQuery : SessionEntity, IRequest<SessionEntity>, IBaseIdentifiable;

public class GetByIdHandler(CollegeContext dataAccessLayer, ILogger<GetByIdHandler> logger)
    : BaseGetByIdHandler<GetByIdQuery, SessionEntity>(dataAccessLayer, logger, "[acc].[usp_GetSessionsById]", "Id");