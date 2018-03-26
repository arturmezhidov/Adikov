using System;
using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Queries.FaqRequests;
using Adikov.Infrastructura.Criterion;
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
                Requests = GetFaqRequests().Select(ToFaqRequest).ToList()
            };

            return context;
        }

        protected IEnumerable<FaqRequestDetail> GetFaqRequests()
        {
            return Query.For<FindPendingFaqRequestsQueryResult>().With(new EmptyCriterion()).Requests;
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
    }
}