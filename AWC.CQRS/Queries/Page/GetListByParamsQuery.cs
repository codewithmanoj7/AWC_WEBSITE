using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities;
using AWC.Infra.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Queries.Page;

public class GetListByParamsQuery(string? name = null, string? description = null)
    : IRequest<List<PageEntity>>, IParameterizedQuery
{
    public Dictionary<string, object?> Parameters { get; } = new()
    {
        { "Name", name },
        { "Description", description }
    };
}

public class GetPagesByParamsQueryHandler(CollegeContext dataAccessLayer, ILogger<GetPagesByParamsQueryHandler> logger)
    : BaseGetListByParamsHandler<GetListByParamsQuery, PageEntity>(
        dataAccessLayer,
        logger,
        "[site].[usp_GetPageByParam]");