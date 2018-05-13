using Adikov.Domain.Models;
using Adikov.Domain.Queries.Settings;
using Adikov.Infrastructura.Criterion;
using System.Collections.Generic;
using System.Linq;

namespace Adikov.Domain.Queries.Contacts
{
    public class GetMessagesQueryResult
    {
        public List<Message> NewMessages { get; set; }

        public List<Message> ReadMessages { get; set; }

        public List<Message> DeletedMessages { get; set; }
    }

    public class GetMessagesQuery : BaseSettingsQuery<EmptyCriterion, GetMessagesQueryResult>
    {
        protected override GetMessagesQueryResult OnExecuting(EmptyCriterion criterion)
        {
            var messages = DataContext.Messages.ToList();

            GetMessagesQueryResult result = new GetMessagesQueryResult
            {
                NewMessages = messages.Where(i => !i.IsRead && !i.IsDeleted).ToList(),
                ReadMessages = messages.Where(i => i.IsRead && !i.IsDeleted).ToList(),
                DeletedMessages = messages.Where(i => i.IsDeleted).ToList()
            };

            return result;
        }
    }
}