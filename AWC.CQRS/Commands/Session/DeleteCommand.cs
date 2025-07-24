using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Commands.Session;
public class DeleteCommand : SessionEntity, IRequest<int>, IBaseIdentifiable;

public class DeleteCommandHandler(CollegeContext dataAccessLayer, ILogger<DeleteCommandHandler> logger)
    : BaseDeleteCommandHandler<DeleteCommand, SessionEntity>(dataAccessLayer, logger, "[acc].[usp_DeleteSessionsByUserId]", "Id");