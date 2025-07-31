using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities.Site;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Queries.News;

public class GetPagedQuery : BaseBO, IRequest<PaginatedQueryResult<NewsEntity>>;

public class GetNewsdNewssQueryHandler(CollegeContext dataAccessLayer, ILogger<GetNewsdNewssQueryHandler> logger)
    : BasePagedQueryHandler<GetPagedQuery, NewsEntity>(dataAccessLayer, logger, "[site].[usp_GetPagedNews]")
{
    protected override void AddParameters(DynamicParameters parameters, GetPagedQuery command)
    {
        parameters.Add("PageNumber", command.PageNumber);
        parameters.Add("PageSize", command.PageSize);
        parameters.Add("CreatedBy", command.CreatedBy);
        parameters.Add("CreatedFrom", command.CreatedFrom);
        parameters.Add("CreatedTo", command.CreatedTo);
        parameters.Add("SearchTerm", command.SearchTerm ?? string.Empty);
    }
}