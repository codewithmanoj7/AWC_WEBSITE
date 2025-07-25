using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using AWC.Infra.Interfaces;

namespace AWC.UI.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IAuthenticationStateService _authService;

        public CustomAuthenticationStateProvider(IAuthenticationStateService authService)
        {
            _authService = authService;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();

            if (_authService.IsAuthenticated && _authService.User != null)
            {
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

                identity = new ClaimsIdentity(claims, "custom");
            }

            var user = new ClaimsPrincipal(identity);
            return Task.FromResult(new AuthenticationState(user));
        }

        public void NotifyUserAuthentication()
        {
            var authState = GetAuthenticationStateAsync();
            NotifyAuthenticationStateChanged(authState);
        }

        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
            NotifyAuthenticationStateChanged(authState);
        }
    }
}