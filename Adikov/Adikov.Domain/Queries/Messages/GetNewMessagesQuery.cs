using Adikov.Domain.Models;
using Adikov.Domain.Queries.Settings;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Adikov.Domain.Queries.Messages
{
    public class MessageDetails
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ImageUrl { get; set; }
    }


    public class GetNewMessagesQueryResult
    {
        public List<MessageDetails> Messages { get; set; }
    }

    public class GetNewMessagesQuery : BaseSettingsQuery<EmptyCriterion, GetNewMessagesQueryResult>
    {
        protected override GetNewMessagesQueryResult OnExecuting(EmptyCriterion criterion)
        {
            var messages = DataContext.Messages.OrderByDescending(i => i.CreatedAt).ToList();

            GetNewMessagesQueryResult result = new GetNewMessagesQueryResult
            {
                Messages = messages.Where(i => !i.IsRead && !i.IsDeleted).Select(ToDetails).ToList()
            };

            return result;
        }

        protected MessageDetails ToDetails(Message message)
        {
            return new MessageDetails
            {
                Id = message.Id,
                Content = message.Content,
                CreatedAt = message.CreatedAt,
                Username = message.Username,
                ImageUrl = PlatformConfiguration.DefaultAvatarPath
            };
        }
    }
}