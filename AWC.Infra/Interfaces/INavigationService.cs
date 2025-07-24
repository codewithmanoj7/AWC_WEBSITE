using Microsoft.AspNetCore.Components.Routing;

namespace AWC.Infra.Interfaces
{
    public interface INavigationService
    {
        /// <summary>
        /// Navigates to the specified URL.
        /// </summary>
        /// <param name="url">The target URL.</param>
        /// <param name="forceLoad">If true, bypasses the Blazor router and forces a full-page reload.</param>
        void NavigateTo(string url, bool forceLoad = false);

        /// <summary>
        /// Navigates to the specified URL with query parameters.
        /// </summary>
        /// <param name="url">The target URL.</param>
        /// <param name="queryParams">A dictionary of query parameters.</param>
        /// <param name="forceLoad">If true, bypasses the Blazor router and forces a full-page reload.</param>
        void NavigateTo(string url, Dictionary<string, string> queryParams, bool forceLoad = false);

        /// <summary>
        /// Gets the current URI.
        /// </summary>
        /// <returns>The current absolute URI.</returns>
        string GetCurrentUri();

        /// <summary>
        /// Converts an absolute URI to a relative URI.
        /// </summary>
        /// <param name="absoluteUri">The absolute URI.</param>
        /// <returns>The relative URI.</returns>
        string ToRelativeUri(string absoluteUri);

        /// <summary>
        /// Converts a relative URI to an absolute URI.
        /// </summary>
        /// <param name="relativeUri">The relative URI.</param>
        /// <returns>The absolute URI.</returns>
        Uri ToAbsoluteUri(string relativeUri);

        /// <summary>
        /// Subscribes to location change events.
        /// </summary>
        /// <param name="handler">The event handler for location changes.</param>
        void SubscribeToLocationChanges(EventHandler<LocationChangedEventArgs> handler);

        /// <summary>
        /// Unsubscribes from location change events.
        /// </summary>
        /// <param name="handler">The event handler to remove.</param>
        void UnsubscribeFromLocationChanges(EventHandler<LocationChangedEventArgs> handler);

        /// <summary>
        /// Forces a refresh of the current page.
        /// </summary>
        void ForceRefresh();

        /// <summary>
        /// Navigates to the previous page in the navigation history.
        /// </summary>
        void NavigateToPreviousPage();

        /// <summary>
        /// Gets the current relative path.
        /// </summary>
        /// <returns>The current relative path.</returns>
        string GetCurrentPath();

        /// <summary>
        /// Gets the previous relative path, if available.
        /// </summary>
        /// <returns>The previous relative path, or null if no previous path exists.</returns>
        string GetPreviousPath();
    }

}
