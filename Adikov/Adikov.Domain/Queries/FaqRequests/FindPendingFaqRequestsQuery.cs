using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.FaqRequests
{
    public class FindPendingFaqRequestsQueryResult
    {
        public IEnumerable<FaqRequestDetail> Requests { get; set; }
    }

    public class FindPendingFaqRequestsQuery : Query<EmptyCriterion, FindPendingFaqRequestsQueryResult>
    {
        protected override FindPendingFaqRequestsQueryResult OnExecuting(EmptyCriterion criterion)
        {
            FaqRequests requests = new FindFaqRequestsQuery().Execute(criterion).Requests;
 
            FindPendingFaqRequestsQueryResult result = new FindPendingFaqRequestsQueryResult
            {
                Requests = requests.PendingRequests.Where(i => i.Status == FaqRequestStatus.Open)
            };

            return result;
        }

    }
}