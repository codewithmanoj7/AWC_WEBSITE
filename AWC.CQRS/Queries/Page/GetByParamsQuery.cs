using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities;
using AWC.Infra.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Queries.Page;
public class GetByParamsQuery(string url) : IRequest<PageEntity>, IParameterizedQuery
{
    public Dictionary<string, object> Parameters { get; } = new()
    {
        { "Url", url }
    };
}

public class GetByParamsQueryHandler(CollegeContext dataAccessLayer, ILogger<GetByParamsQueryHandler> logger) 
    : BaseGetByParamsHandler<GetByParamsQuery, PageEntity>(dataAccessLayer, logger, 
        "[site].[usp_GetPageByUrl]");