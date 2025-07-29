using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Queries.User
{
    public class GetPagedQuery : BaseBO, IRequest<PaginatedQueryResult<UserEntity>>
    {
    }
    public class GetPagedQueryHandler(CollegeContext dataAccessLayer, ILogger<GetPagedQueryHandler> logger)
                : BasePagedQueryHandler<GetPagedQuery, UserEntity>(dataAccessLayer, logger, "acc.usp_GetPagedUsers")
    {
        protected override void AddParameters(DynamicParameters parameters, GetPagedQuery command)
        {
            parameters.Add("PageNumber", command.PageNumber);
            parameters.Add("PageSize", command.PageSize);
            parameters.Add("SearchTerm", command.SearchTerm ?? string.Empty);
        }
    }
}
