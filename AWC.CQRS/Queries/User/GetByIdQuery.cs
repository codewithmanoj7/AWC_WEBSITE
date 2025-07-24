using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Queries.User
{
    public class GetByIdQuery : UserEntity, IRequest<UserEntity>, IBaseIdentifiable
    {
    }

    public class GetByIdHandler(CollegeContext dataAccessLayer, ILogger<GetByIdHandler> logger)
        : BaseGetByIdHandler<GetByIdQuery, UserEntity>(dataAccessLayer, logger, "[acc].[usp_GetUserById]", "Id")
    {
    }
}
