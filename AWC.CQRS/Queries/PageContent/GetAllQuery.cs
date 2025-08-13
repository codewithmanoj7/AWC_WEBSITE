using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities;
using AWC.Infra.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWC.CQRS.Queries.PageContent
{
    // Get All Page Contents
    public class GetAllQuery : IRequest<IList<PageContentEntity>> { }

    public class GetAllPageContentsQueryHandler : BaseGetAllQueryHandler<GetAllQuery, PageContentEntity>
    {
        public GetAllPageContentsQueryHandler(CollegeContext dataAccessLayer, ILogger<GetAllPageContentsQueryHandler> logger)
            : base(dataAccessLayer, logger, "[site].[usp_GetAllPageContents]")
        {
        }
    }

    // Get Page Content by ID
    public class GetByIdQuery : IRequest<PageContentEntity>, IBaseIdentifiable
    {
        public Guid Id { get; set; }
    }

    public class GetPageContentByIdQueryHandler : BaseGetByIdHandler<GetByIdQuery, PageContentEntity>
    {
        public GetPageContentByIdQueryHandler(CollegeContext dataAccessLayer, ILogger<GetPageContentByIdQueryHandler> logger)
            : base(dataAccessLayer, logger, "[site].[usp_GetPageContentById]", "Id")
        {
        }
    }

    // Get Page Content by Navigation Menu ID
    public class GetByNavigationMenuQuery : IRequest<IList<PageContentEntity>>
    {
        public Guid NavigationMenuId { get; set; }

        public GetByNavigationMenuQuery(Guid navigationMenuId)
        {
            NavigationMenuId = navigationMenuId;
        }
    }

    public class GetByNavigationMenuQueryHandler : IRequestHandler<GetByNavigationMenuQuery, IList<PageContentEntity>>
    {
        private readonly CollegeContext _dataAccessLayer;
        private readonly ILogger<GetByNavigationMenuQueryHandler> _logger;

        public GetByNavigationMenuQueryHandler(CollegeContext dataAccessLayer, ILogger<GetByNavigationMenuQueryHandler> logger)
        {
            _dataAccessLayer = dataAccessLayer;
            _logger = logger;
        }

        public async Task<IList<PageContentEntity>> Handle(GetByNavigationMenuQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Fetching page contents for navigation menu ID: {NavigationMenuId}", request.NavigationMenuId);

                var parameters = new Dictionary<string, object>
                {
                    ["NavigationMenuId"] = request.NavigationMenuId
                };

                var entities = await _dataAccessLayer.ExecuteQueryAsync<PageContentEntity>(
                    "[site].[usp_GetPageContentByNavigationId]",
                    parameters);

                var result = entities?.ToList() ?? new List<PageContentEntity>();

                if (result.Any())
                {
                    _logger.LogInformation("{EntityCount} page contents fetched successfully for navigation menu ID: {NavigationMenuId}",
                        result.Count, request.NavigationMenuId);
                }
                else
                {
                    _logger.LogWarning("No page contents found for navigation menu ID: {NavigationMenuId}", request.NavigationMenuId);
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching page contents for navigation menu ID: {NavigationMenuId}",
                    request.NavigationMenuId);
                throw;
            }
        }
    }

    // Get Page Content by URL
    public class GetByUrlQuery : IRequest<PageContentEntity>
    {
        public string Url { get; set; }

        public GetByUrlQuery(string url)
        {
            Url = url;
        }
    }

    public class GetByUrlQueryHandler : IRequestHandler<GetByUrlQuery, PageContentEntity>
    {
        private readonly CollegeContext _dataAccessLayer;
        private readonly ILogger<GetByUrlQueryHandler> _logger;

        public GetByUrlQueryHandler(CollegeContext dataAccessLayer, ILogger<GetByUrlQueryHandler> logger)
        {
            _dataAccessLayer = dataAccessLayer;
            _logger = logger;
        }

        public async Task<PageContentEntity> Handle(GetByUrlQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Fetching page content for URL: {Url}", request.Url);

                var parameters = new Dictionary<string, object>
                {
                    ["Url"] = request.Url
                };

                var entities = await _dataAccessLayer.ExecuteQueryAsync<PageContentEntity>(
                    "[site].[usp_GetPageContentByUrl]",
                    parameters);

                var result = entities?.FirstOrDefault();

                if (result != null)
                {
                    _logger.LogInformation("Page content fetched successfully for URL: {Url}", request.Url);
                }
                else
                {
                    _logger.LogWarning("No page content found for URL: {Url}", request.Url);
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching page content for URL: {Url}", request.Url);
                throw;
            }
        }
    }

    // Search Page Contents
    public class SearchQuery : IRequest<IList<PageContentEntity>>
    {
        public string? SearchTerm { get; set; }
        public Guid? NavigationMenuId { get; set; }
        public bool? IsActive { get; set; }

        public SearchQuery(string? searchTerm = null, Guid? navigationMenuId = null, bool? isActive = null)
        {
            SearchTerm = searchTerm;
            NavigationMenuId = navigationMenuId;
            IsActive = isActive;
        }
    }

    public class SearchQueryHandler : IRequestHandler<SearchQuery, IList<PageContentEntity>>
    {
        private readonly CollegeContext _dataAccessLayer;
        private readonly ILogger<SearchQueryHandler> _logger;

        public SearchQueryHandler(CollegeContext dataAccessLayer, ILogger<SearchQueryHandler> logger)
        {
            _dataAccessLayer = dataAccessLayer;
            _logger = logger;
        }

        public async Task<IList<PageContentEntity>> Handle(SearchQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Searching page contents with term: {SearchTerm}, NavigationMenuId: {NavigationMenuId}, IsActive: {IsActive}",
                    request.SearchTerm, request.NavigationMenuId, request.IsActive);

                var parameters = new Dictionary<string, object>
                {
                    ["SearchTerm"] = request.SearchTerm,
                    ["NavigationMenuId"] = request.NavigationMenuId,
                    ["IsActive"] = request.IsActive
                };

                var entities = await _dataAccessLayer.ExecuteQueryAsync<PageContentEntity>(
                    "[site].[usp_SearchPageContents]",
                    parameters);

                var result = entities?.ToList() ?? new List<PageContentEntity>();

                if (result.Any())
                {
                    _logger.LogInformation("{EntityCount} page contents found matching search criteria", result.Count);
                }
                else
                {
                    _logger.LogWarning("No page contents found matching search criteria");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while searching page contents");
                throw;
            }
        }
    }

    // Get Breadcrumb by URL
    public class GetBreadcrumbQuery : IRequest<IList<NavigationMenuEntity>>
    {
        public string Url { get; set; }

        public GetBreadcrumbQuery(string url)
        {
            Url = url;
        }
    }

    public class GetBreadcrumbQueryHandler : IRequestHandler<GetBreadcrumbQuery, IList<NavigationMenuEntity>>
    {
        private readonly CollegeContext _dataAccessLayer;
        private readonly ILogger<GetBreadcrumbQueryHandler> _logger;

        public GetBreadcrumbQueryHandler(CollegeContext dataAccessLayer, ILogger<GetBreadcrumbQueryHandler> logger)
        {
            _dataAccessLayer = dataAccessLayer;
            _logger = logger;
        }

        public async Task<IList<NavigationMenuEntity>> Handle(GetBreadcrumbQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Fetching breadcrumb navigation for URL: {Url}", request.Url);

                var parameters = new Dictionary<string, object>
                {
                    ["Url"] = request.Url
                };

                var entities = await _dataAccessLayer.ExecuteQueryAsync<NavigationMenuEntity>(
                    "[site].[usp_GetBreadcrumbByUrl]",
                    parameters);

                var result = entities?.ToList() ?? new List<NavigationMenuEntity>();

                if (result.Any())
                {
                    _logger.LogInformation("Breadcrumb navigation fetched successfully for URL: {Url}", request.Url);
                }
                else
                {
                    _logger.LogWarning("No breadcrumb navigation found for URL: {Url}", request.Url);
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching breadcrumb navigation for URL: {Url}", request.Url);
                throw;
            }
        }
    }
}