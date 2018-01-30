using System.Collections.Generic;

namespace Adikov.Models.Sidebar
{
    public interface ISidebarContext
    {
        IEnumerable<SidebarGroup> Groups { get; }
    }
}