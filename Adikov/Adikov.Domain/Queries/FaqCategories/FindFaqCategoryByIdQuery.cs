using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.FaqCategories
{
    public class FindFaqCategoryByIdQueryResult
    {
        public FaqCategory Category { get; set; }

        public bool IsFoundCategory { get; set; }
    }

    public class FindFaqCategoryByIdQuery : Query<IdCriterion, FindFaqCategoryByIdQueryResult>
    {
        protected override FindFaqCategoryByIdQueryResult OnExecuting(IdCriterion criterion)
        {
            FaqCategory category = DataContext.FaqCategories.Find(criterion.Id);

            FindFaqCategoryByIdQueryResult result = new FindFaqCategoryByIdQueryResult
            {
                Category = category,
                IsFoundCategory = category != null
            };

            return result;
        }
    }
}