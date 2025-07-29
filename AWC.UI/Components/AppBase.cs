using AWC.Infra.Interfaces;
using Microsoft.AspNetCore.Components;

namespace AWC.UI.Components
{
    public class AppBase : ComponentBase
    {
        [Inject] protected INavigationService? NavigationService { get; set; }

        public AppBase()
        {

        }
    }
}
