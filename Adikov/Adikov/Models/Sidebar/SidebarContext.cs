using System.Collections.Generic;

namespace Adikov.Models.Sidebar
{
    public class SidebarContext
    {
        public List<SidebarGroup> Groups { get; set; }

        public SidebarContext()
        {
            Groups = new List<SidebarGroup>();
        }
    }
}