using System;
using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Queries.FaqRequests;
using Adikov.Domain.Queries.Messages;
using Adikov.Infrastructura.Queries;
using Adikov.Models.Menu;
using FaqRequest = Adikov.Models.Menu.FaqRequest;

namespace Adikov.Services
{
    public interface IMenuService
    {
        IMenuContext CreateContext();
    }

    public class MenuService : IMenuService
    {
        protected IQueryBuilder Query { get; }

        public MenuService(IQueryBuilder query)
        {
            Query = query ?? throw new ArgumentNullException(nameof(query));
        }

        public IMenuContext CreateContext()
        {
            IMenuContext context = new MenuContext
            {
                Requests = GetFaqRequests().Select(ToFaqRequest).ToList(),
                Messages = GetMessages().Select(ToMessage).ToList()
            };

            return context;
        }

        protected IEnumerable<FaqRequestDetail> GetFaqRequests()
        {
            return Query.For<FindPendingFaqRequestsQueryResult>().Empty().Requests;
        }

        protected IEnumerable<MessageDetails> GetMessages()
        {
            return Query.For<GetNewMessagesQueryResult>().Empty().Messages;
        }

        private FaqRequest ToFaqRequest(FaqRequestDetail request)
        {
            return new FaqRequest
            {
                Id = request.Id,
                Question = request.Question,
                CreatedBy = request.CreatedBy,
                CreatedAt = request.CreatedAt,
                AvatarLink = request.AvatarLink
            };
        }

        private Message ToMessage(MessageDetails message)
        {
            return new Message
            {
                Id = message.Id,
                Username = message.Username,
                Content = message.Content,
                CreatedAt = message.CreatedAt,
                ImageUrl = message.ImageUrl
            };
        }
    }
}