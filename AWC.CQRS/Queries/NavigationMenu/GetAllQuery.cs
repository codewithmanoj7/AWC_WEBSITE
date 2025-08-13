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

namespace AWC.CQRS.Queries.NavigationMenu
{
    public class GetAllQuery : IRequest<IList<NavigationMenuEntity>> { }

    public class GetAllNavigationMenusQueryHandler(CollegeContext dataAccessLayer, ILogger<GetAllNavigationMenusQueryHandler> logger)
        : BaseGetAllQueryHandler<GetAllQuery, NavigationMenuEntity>(dataAccessLayer, logger, "[site].[usp_GetAllNavigationMenus]");

    // Get Navigation Menu by ID
    public class GetByIdQuery : NavigationMenuEntity, IRequest<NavigationMenuEntity>, IBaseIdentifiable
    {
    }

    public class GetNavigationMenuByIdQueryHandler(CollegeContext dataAccessLayer, ILogger<GetNavigationMenuByIdQueryHandler> logger)
        : BaseGetByIdHandler<GetByIdQuery, NavigationMenuEntity>(dataAccessLayer, logger, "[site].[usp_GetNavigationMenuById]", "Id");

    // Get Active Navigation Menus (for frontend display)
    public class GetActiveQuery : IRequest<IList<NavigationMenuEntity>> { }

    public class GetActiveNavigationMenusQueryHandler(CollegeContext dataAccessLayer, ILogger<GetActiveNavigationMenusQueryHandler> logger)
        : BaseGetAllQueryHandler<GetActiveQuery, NavigationMenuEntity>(dataAccessLayer, logger, "[site].[usp_GetActiveNavigationMenus]");

    // Get Navigation Menus by Parent ID
    public class GetByParentQuery : IRequest<IList<NavigationMenuEntity>>, IParameterizedQuery
    {
        public Guid? ParentId { get; set; }

        public Dictionary<string, object> Parameters { get; } = new Dictionary<string, object>();

        public GetByParentQuery(Guid? parentId)
        {
            ParentId = parentId;
            Parameters.Add("ParentId", parentId);
        }
    }

    //public class GetByParentQueryHandler(CollegeContext dataAccessLayer, ILogger<GetByParentQueryHandler> logger)
    //    : BaseGetByParamsHandler<GetByParentQuery, NavigationMenuEntity>(dataAccessLayer, logger, "[site].[usp_GetNavigationMenusByParent]");
}