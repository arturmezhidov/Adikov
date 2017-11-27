using System.Collections.Generic;

namespace Adikov.Models.Sidebar
{
    public class SidebarGroup
    {
        public string Icon { get; set; }

        public string Text { get; set; }

        public string ViewLink { get; set; }

        public bool IsActive { get; set; }

        public List<SidebarItem> Items { get; set; }

        public SidebarGroup()
        {
            Items = new List<SidebarItem>();
        }
    }
}