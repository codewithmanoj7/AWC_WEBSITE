using AWC.CQRS.Commands.Session;
using AWC.CQRS.Queries.User;
using AWC.Infra.Consts;
using AWC.Infra.Entities;
using AWC.Infra.Enums;
using AWC.Infra.Interfaces;
using AWC.Infra.Models;
using AWC.UI.Services.Exceptions;
using MediatR;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AWC.UI.Services
{
    public class AuthenticationStateService(IHttpContextAccessor httpcontext, ITokenService tokenService, IMediator mediator) : IAuthenticationStateService
    {
        public bool IsAuthenticated { get => httpcontext.HttpContext?.User.Identity?.IsAuthenticated ?? false; }
        public Guid? SessionId { get => httpcontext.HttpContext?.Items["SessionId"] as Guid?; }

        public UserEntity? User
        {
            get => httpcontext.HttpContext?.Items["UserEntity"] as UserEntity;
            set
            {
                if (httpcontext.HttpContext != null)
                    httpcontext.HttpContext.Items["UserEntity"] = value;
            }
        }

        public async Task<CookieModel> CreateJwtSessionToken(string icNumber, string password, bool remember)
        {
            var query = new GetByParams(icNumber);
            var user = await mediator.Send(query);
            if (user != null)
            {
                var salt = user.PasswordSalt;
                using HMACSHA512 hmac = new(salt);
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                if (user.PasswordHash.SequenceEqual(hash))
                {
                    if (user.Permissions == UserPermissionsEnum.WaitingApproval) throw new UnapprovedUserException();


                    var session = new SessionEntity
                    {
                        UserId = user.Id,
                        ExpireAt = remember ? DateTime.Now.Add(CookiesConst.AccessCookieExpire) : DateTime.Now.Add(CookiesConst.AccessCookieExpireTemp)
                    };
                    var command = new UpsertCommand
                    {
                        UserId = session.UserId,
                        ExpireAt = session.ExpireAt
                    };

                    // Call the command handler to create or update the category
                    var result = await mediator.Send(command);
                    if (result.Result == 1)
                    {
                        var accessToken = tokenService.GenerateAccessToken(
                        [
#nullable disable
                            new(ClaimTypes.Sid, value: result.InsertedId.ToString())
                        ], session.ExpireAt);

                        return new CookieModel(accessToken, session.ExpireAt);
                    }
                }
            }
            throw new InvalidCredentialsException();
        }
    }

}
