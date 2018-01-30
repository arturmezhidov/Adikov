using System.Collections.Generic;

namespace Adikov.Models.Sidebar
{
    public class SidebarContext : ISidebarContext
    {
        public IEnumerable<SidebarGroup> Groups { get; set; }
    }
}