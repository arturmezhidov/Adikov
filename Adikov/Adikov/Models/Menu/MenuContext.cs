using System.Collections.Generic;

namespace Adikov.Models.Menu
{
    public class MenuContext : IMenuContext
    {
        public List<FaqRequest> Requests { get; set; }

        public int RequestsCount => Requests?.Count ?? 0;

        public List<Message> Messages { get; set; }

        public int MessagesCount => Messages?.Count ?? 0;
    }
}