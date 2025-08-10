using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Queries.Page;

public class GetPagedQuery : BaseBO, IRequest<PaginatedQueryResult<PageEntity>>;

public class GetPagedPagesQueryHandler(CollegeContext dataAccessLayer, ILogger<GetPagedPagesQueryHandler> logger)
    : BasePagedQueryHandler<GetPagedQuery, PageEntity>(dataAccessLayer, logger, "[site].[usp_GetPagedPages]")
{
    protected override void AddParameters(DynamicParameters parameters, GetPagedQuery command)
    {
        parameters.Add("PageNumber", command.PageNumber);
        parameters.Add("PageSize", command.PageSize);
        parameters.Add("CreatedBy", command.CreatedBy);
        parameters.Add("SearchTerm", command.SearchTerm ?? string.Empty);
    }
}