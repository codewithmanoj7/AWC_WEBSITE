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

namespace AWC.CQRS.Queries.User
{
    public class GetByParams(string icNumber) : IRequest<UserEntity>, IParameterizedQuery
    {
        public Dictionary<string, object> Parameters { get; } = new()
        {
            { "ICnumber", icNumber }
        };
    }

    public class GetByParamsHandler(CollegeContext dataAccessLayer, ILogger<GetByParamsHandler> logger)
        : BaseGetByParamsHandler<GetByParams, UserEntity>(dataAccessLayer, logger, "[acc].[usp_GetUserByICnumber]")
    {
    }
}
