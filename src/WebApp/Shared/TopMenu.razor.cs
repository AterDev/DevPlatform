using System.Collections.Generic;
using System.Threading.Tasks;


namespace WebApp.Shared
{
    public partial class TopMenu
    {
        private bool collapseNavMenu = false;
        private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;


        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

    }

}
