using System.Collections.Generic;
using System.Threading.Tasks;


namespace WebApp.Pages.Portal.Shared
{
    public partial class NavMenu
    {
        private bool collapseNavMenu = false;
        private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;


        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

    }

}
