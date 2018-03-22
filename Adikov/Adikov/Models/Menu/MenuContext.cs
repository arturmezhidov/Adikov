using System.Collections.Generic;

namespace Adikov.Models.Menu
{
    public class MenuContext : IMenuContext
    {
        public List<FaqRequest> Requests { get; set; }

        public int RequestsCount => Requests?.Count ?? 0;
    }
}