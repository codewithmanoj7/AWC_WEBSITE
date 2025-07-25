using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;
using AWC.Infra.Interfaces;
using AWC.Infra.Enums;

namespace AWC.UI.Components
{
    public class RenderPermission : ComponentBase
    {
#nullable disable
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public bool RedirectIfInvalid { get; set; }
        [Parameter] public string RedirectUrl { get; set; } = "/";
        [Parameter] public bool RedirectForce { get; set; }
        [Inject] public IAuthenticationStateService AuthenticationState { get; set; }
        [Inject] public INavigationService NavigationService { get; set; }
#nullable enable

        [Parameter] public UserPermissionsEnum[]? Permissions { get; set; }
        [Parameter] public UserPermissionsEnum? Permission { get; set; }

        // Override OnAfterRenderAsync and return a Task
        protected override void OnAfterRender(bool firstRender)
        {
            // Perform the navigation only once when the component is first rendered.
            if (firstRender && RedirectIfInvalid)
            {
                // Check if the user has valid permissions
                bool hasPermission = (Permissions != null && Permissions.Any(x => x == AuthenticationState.User?.Permissions)) ||
                                     (Permission != null && Permission == AuthenticationState.User?.Permissions);

                // Redirect if no permissions
                if (!hasPermission)
                {
                    try
                    {
                        NavigationService.NavigateTo(RedirectUrl);
                    }
                    catch (Exception ex)
                    {
                        // Log the error for debugging purposes
                        Console.Error.WriteLine($"Navigation to {RedirectUrl} failed: {ex}");
                    }
                }
            }
        }

        // Render content only if the user has valid permissions
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            bool hasPermission = (Permissions != null && Permissions.Any(x => x == AuthenticationState.User?.Permissions)) ||
                                 (Permission != null && Permission == AuthenticationState.User?.Permissions);

            if (hasPermission)
            {
                base.BuildRenderTree(builder);
                builder.OpenRegion(0);
                builder.AddContent(1, ChildContent);
                builder.CloseRegion();
            }
        }
    }
}
