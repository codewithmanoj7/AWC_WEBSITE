using AWC.Infra.Bases;
using AWC.Infra.Data;
using AWC.Infra.Entities;
using AWC.Infra.Results;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Data;

namespace AWC.CQRS.Commands.User
{
    public class UpsertCommand : UserEntity, IRequest<UpsertCommandResult>
    {
    }
    public class UserCommandHandler(CollegeContext dataAccessLayer, ILogger<UserCommandHandler> logger)
       : BaseUpsertCommandHandler<UpsertCommand, UserEntity>(dataAccessLayer, logger, "[acc].[usp_InsertOrUpdateUser]")
    {
        protected override void AddParameters(DynamicParameters parameters, UpsertCommand command)
        {
            parameters.Add("Id", command.Id);
            parameters.Add("ICnumber", command.ICnumber.Trim());
            parameters.Add("PasswordHash", command.PasswordHash, DbType.Binary);
            parameters.Add("PasswordSalt", command.PasswordSalt, DbType.Binary);
            parameters.Add("FirstName", command.FirstName.Trim());
            parameters.Add("LastName", command.LastName.Trim());
            parameters.Add("Email", command.Email.Trim());
            parameters.Add("PhoneNumber", command.PhoneNumber.Trim());
            parameters.Add("Country", command.Country.Trim());
            parameters.Add("City", command.City.Trim());
            parameters.Add("Gender", (int)command.Gender);
            parameters.Add("Permissions", (int)command.Permissions);
            parameters.Add("CreatedBy", command.CreatedBy);
            parameters.Add("UpdatedBy", command.UpdatedBy);
        }
    }
}
