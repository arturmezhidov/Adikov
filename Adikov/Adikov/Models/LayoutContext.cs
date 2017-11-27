using Adikov.Infrastructura.Security;
using Adikov.Models.Sidebar;

namespace Adikov.Models
{
    public class LayoutContext
    {
        public string LogoUrl { get; set; }

        public IUserContext User { get; set; }

        public SidebarContext Sidebar { get; set; }
    }
}