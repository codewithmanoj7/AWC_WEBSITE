using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities.Site;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Queries.Gallery;

public class GetPagedQuery : BaseBO, IRequest<PaginatedQueryResult<GalleryEntity>>;

public class GetGallerydGallerysQueryHandler(CollegeContext dataAccessLayer, ILogger<GetGallerydGallerysQueryHandler> logger)
    : BasePagedQueryHandler<GetPagedQuery, GalleryEntity>(dataAccessLayer, logger, "[site].[usp_GetPagedGallery]")
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