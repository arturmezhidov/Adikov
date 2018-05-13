using System.Collections.Generic;

namespace Adikov.Models.Menu
{
    public interface IMenuContext
    {
        List<FaqRequest> Requests { get; set; }

        int RequestsCount { get; }

        List<Message> Messages { get; set; }

        int MessagesCount { get; }
    }
}