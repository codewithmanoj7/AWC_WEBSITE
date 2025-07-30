using AWC.Infra.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace AWC.UI.Components
{
    public class AppBase : ComponentBase
    {
        [Inject] protected INavigationService? NavigationService { get; set; }
        [Inject] protected NavigationManager? NavigationManager { get; set; }

        [CascadingParameter] private Task<AuthenticationState>? AuthenticationStateTask { get; set; }

        private bool _hasRedirected = false;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && !_hasRedirected && AuthenticationStateTask != null)
            {
                var authState = await AuthenticationStateTask;
                var user = authState.User;

                if (user.Identity is { IsAuthenticated: true })
                {
                    if (NavigationManager != null && NavigationManager.Uri.EndsWith("/"))
                    {
                        _hasRedirected = true;
                        NavigationManager.NavigateTo("/home", forceLoad: true);
                    }
                }
            }
        }
    }
}

