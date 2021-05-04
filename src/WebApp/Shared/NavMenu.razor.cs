using System.Collections.Generic;
using System.Threading.Tasks;


namespace WebApp.Shared
{
    public partial class NavMenu
    {
        private bool collapseNavMenu = false;
        private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        protected override async Task OnInitializedAsync()
        {
        }
        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

    }

}
