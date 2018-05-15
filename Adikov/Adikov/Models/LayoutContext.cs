using Adikov.Infrastructura.Security;
using Adikov.Models.Menu;
using Adikov.Models.Sidebar;

namespace Adikov.Models
{
    public class LayoutContext
    {
        public string LogoUrl { get; set; }

        public IUserContext User { get; set; }

        public ISidebarContext Sidebar { get; set; }

        public IMenuContext Menu { get; set; }

        public string ContollerName { get; set; }

        public string ActionName { get; set; }
    }
}