using AWC.CQRS.Commands.Session;
using AWC.CQRS.Queries.Session;
using AWC.Infra.Consts;
using AWC.Infra.Enums;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace AWC.UI.Services
{
    public class ConfigureJwtBearerOptions(IMediator mediator) : IConfigureNamedOptions<JwtBearerOptions>
    {
#nullable disable
        public void Configure(string name, JwtBearerOptions options)
        {
            options.Events = new JwtExtendedValidationService(mediator);
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = CookiesConst.IssuerAndAudience,
                ValidAudience = CookiesConst.IssuerAndAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(CookiesConst.SecretTokenKey))
            };
        }

        public void Configure(JwtBearerOptions options)
        {
            Configure(string.Empty, options);
        }
    }

    public class JwtExtendedValidationService(IMediator mediator) : JwtBearerEvents
    {
        public override Task MessageReceived(MessageReceivedContext context)
        {
            if (context.Request.Cookies.ContainsKey(CookiesConst.AccessCookie))
            {
                context.Token = context.Request.Cookies[CookiesConst.AccessCookie];
            }

            return Task.CompletedTask;
        }

        public override Task AuthenticationFailed(AuthenticationFailedContext context)
        {
            ResetSessionCookies(context);
            return Task.CompletedTask;
        }

        public override async Task TokenValidated(TokenValidatedContext context)
        {
            if (context.Principal != null)
            {
                var sessionIdClaim = context.Principal.FindFirstValue(ClaimTypes.Sid);

                if (!string.IsNullOrEmpty(sessionIdClaim))
                {
                    // if (context.HttpContext.Request.Path.Equals("/_blazor") || context.HttpContext.Request.Path.Equals("/"))
                    // {
                    var sessoinQuery = new GetByIdQuery { Id = new Guid(sessionIdClaim) };
                    var session = await mediator.Send(sessoinQuery);
                    if (session != null)
                    {
                        var userQuery = new CQRS.Queries.User.GetByIdQuery { Id = session.UserId };
                        var user = await mediator.Send(userQuery);

                        if (user != null)
                        {
                            if (session.ExpireAt > DateTime.Now &&
                                user.Permissions > UserPermissionsEnum.WaitingApproval)
                            {
                                context.HttpContext.Items["SessionId"] = session.Id;
                                context.HttpContext.Items["UserEntity"] = user;
                                context.Success();
                                return;
                            }

                            await mediator.Send(new DeleteCommand { Id = session.Id });
                        }
                        // }

                        ResetSessionCookies(context);
                        context.Fail("Session expired");
                    }
                }
            }
        }

        private void ResetSessionCookies(ResultContext<JwtBearerOptions> context)
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = new DateTime(1970, 1, 1, 0, 0, 0);
            context.Response.Cookies.Append(CookiesConst.AccessCookie, "", cookieOptions);
        }
    }


}
