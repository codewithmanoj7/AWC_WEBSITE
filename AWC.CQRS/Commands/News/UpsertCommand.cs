using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities.Site;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AWC.CQRS.Commands.News;

public class UpsertCommand : NewsEntity, IRequest<UpsertCommandResult>;

public class NewsCommandHandler(CollegeContext dataAccessLayer, ILogger<NewsCommandHandler> logger)
    : BaseUpsertCommandHandler<UpsertCommand, NewsEntity>(dataAccessLayer, logger, "[site].[usp_InsertOrUpdateNews]")
{
    protected override void AddParameters(DynamicParameters parameters, UpsertCommand command)
    {
        parameters.Add("Id", command.Id);
        parameters.Add("Name", command.Name);
        parameters.Add("Description", command.Description);
        parameters.Add("Image", command.Image);
        parameters.Add("CreatedBy", command.CreatedBy);
        parameters.Add("UpdatedBy", command.UpdatedBy);
    }
}