using Med.Core.Handlers;
using Med.Web.Security;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Med.Web.Pages.Identity;

public partial class LogoutPage : ComponentBase
{
    #region Services

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public IAccountHandler Handler { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    public ICookieAuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        // No conditional: if logout depended on an auth check that makes a
        // request, a network failure would skip the logout and the session would stay alive.
        try
        {
            await Handler.LogoutAsync();
        }
        catch
        {
            // Even if the server doesn't respond, we proceed to the reload below.
        }

        await base.OnInitializedAsync();
    }

    #endregion

    #region Methods

    // Reloads the whole application instead of calling
    // NotifyAuthenticationStateChanged. The notify would make the AuthorizeRouteView
    // discard and recreate this page, re-running OnInitializedAsync; the
    // reload resets everything and the auth state is rebuilt from scratch,
    // based on the cookie that was just deleted.
    public void GoToLogin()
        => NavigationManager.NavigateTo("/login", forceLoad: true);

    #endregion
}
