using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.FaqItems
{
    public class FindFaqItemByIdQueryResult
    {
        public FaqItem Item { get; set; }

        public bool IsFounded { get; set; }
    }

    public class FindFaqItemByIdQuery : Query<IdCriterion, FindFaqItemByIdQueryResult>
    {
        protected override FindFaqItemByIdQueryResult OnExecuting(IdCriterion criterion)
        {
            FaqItem item = DataContext.FaqItems.Find(criterion.Id);

            FindFaqItemByIdQueryResult result = new FindFaqItemByIdQueryResult
            {
                Item = item,
                IsFounded = item != null
            };

            return result;
        }
    }
}