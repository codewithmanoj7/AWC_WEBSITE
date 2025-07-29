using AWC.CQRS.Commands.Session;
using AWC.CQRS.Queries.Session;
using AWC.Infra.Consts;
using AWC.Infra.Entities;
using AWC.Infra.Interfaces;
using AWC.UI.Services.Extensions;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.JSInterop;

namespace AWC.UI.Components
{
    public class Logout : ComponentBase
    {
#nullable disable
        [Inject] public IAuthenticationStateService AuthService { get; set; }
        [Inject] public IMediator Mediator { get; set; }
        [Inject] public IJSRuntime JsRuntime { get; set; }
        [Inject] public NavigationManager NavManager { get; set; }
#nullable enable

        protected override async Task OnInitializedAsync()
        
        
        {
            if (AuthService?.IsAuthenticated == true && AuthService.SessionId != null)
            {
                var sessionId = AuthService.SessionId ?? Guid.Empty;
                var sessoinQuery = new GetByIdQuery { Id = sessionId };
                SessionEntity? session = await Mediator.Send(sessoinQuery);
                if (session != null)
                {
                    await Mediator.Send(new DeleteCommand { Id = session.Id });
                }
                await JsRuntime.DeleteCookie(CookiesConst.AccessCookie);
                NavManager.NavigateTo("/auth/login", forceLoad: true);
            }
            NavManager.Refresh();
        }
    }
}
