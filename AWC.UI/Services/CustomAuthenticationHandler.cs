using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Text.Encodings.Web;
using AWC.Infra.Interfaces;
using Microsoft.Extensions.Options;

namespace AWC.UI.Services
{
    public class CustomAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IAuthenticationStateService _authService;

        public CustomAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IAuthenticationStateService authService)
            : base(options, logger, encoder, clock)
        {
            _authService = authService;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!_authService.IsAuthenticated || _authService.User == null)
            {
                return Task.FromResult(AuthenticateResult.Fail("Not authenticated"));
            }

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, $"{_authService.User.FirstName} {_authService.User.LastName}"),
                new(ClaimTypes.NameIdentifier, _authService.User.Id.ToString()),
                new("ICNumber", _authService.User.ICnumber ?? ""),
                new("Permission", _authService.User.Permissions.ToString())
            };

            if (_authService.SessionId.HasValue)
            {
                claims.Add(new Claim(ClaimTypes.Sid, _authService.SessionId.Value.ToString()));
            }

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}