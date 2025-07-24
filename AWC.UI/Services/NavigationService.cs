using AWC.Infra.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace AWC.UI.Services
{
    public class NavigationService : INavigationService, IDisposable
    {
        private readonly NavigationManager _navigationManager;
        private readonly Stack<string> _navigationHistory = new();
        private bool _disposed;

        public NavigationService(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
#nullable disable
            _navigationManager.LocationChanged += TrackNavigationHistory;
        }

        public void NavigateTo(string url, bool forceLoad = false)
        {
            _navigationManager.NavigateTo(url, forceLoad);
        }

        public void NavigateTo(string url, Dictionary<string, string> queryParams, bool forceLoad = false)
        {
            var queryString = string.Join("&", queryParams.Select(qp => $"{qp.Key}={Uri.EscapeDataString(qp.Value)}"));
            var fullUrl = $"{url}?{queryString}";
            _navigationManager.NavigateTo(fullUrl, forceLoad);
        }

        public string GetCurrentUri()
        {
            return _navigationManager.Uri;
        }

        public string ToRelativeUri(string absoluteUri)
        {
            return _navigationManager.ToBaseRelativePath(absoluteUri);
        }

        public Uri ToAbsoluteUri(string relativeUri)
        {
            return _navigationManager.ToAbsoluteUri(relativeUri);
        }

        public void SubscribeToLocationChanges(EventHandler<LocationChangedEventArgs> handler)
        {
            _navigationManager.LocationChanged += handler;
        }

        public void UnsubscribeFromLocationChanges(EventHandler<LocationChangedEventArgs> handler)
        {
            _navigationManager.LocationChanged -= handler;
        }

        public void ForceRefresh()
        {
            var currentUrl = _navigationManager.Uri;
            _navigationManager.NavigateTo(currentUrl, true);
        }

        public void NavigateToPreviousPage()
        {
            if (_navigationHistory.Count > 1)
            {
                // Remove the current page from history
                _navigationHistory.Pop();
                // Navigate to the previous page
                var previousPage = _navigationHistory.Peek();
                _navigationManager.NavigateTo(previousPage);
            }
        }

        private void TrackNavigationHistory(object sender, LocationChangedEventArgs args)
        {
            // Track the navigation history
            _navigationHistory.Push(args.Location);
        }

        public string GetCurrentPath()
        {
            return ToRelativeUri(_navigationManager.Uri);
        }

        public string GetPreviousPath()
        {
            if (_navigationHistory.Count > 1)
            {
                // Remove the current page from history to access the previous one
                var currentPage = _navigationHistory.Pop();
                var previousPage = _navigationHistory.Peek();
                _navigationHistory.Push(currentPage); // Restore the current page
                return ToRelativeUri(previousPage);
            }

            return null; // No previous page available
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _navigationManager.LocationChanged -= TrackNavigationHistory;
                _disposed = true;
            }
        }
    }

}
