using Adikov.Domain.Models;
using System.Collections.Generic;

namespace Adikov.ViewModels.Messages
{
    public class MessagesViewModel
    {
        public List<Message> NewMessages { get; set; }

        public List<Message> ReadMessages { get; set; }

        public List<Message> DeletedMessages { get; set; }
    }
}