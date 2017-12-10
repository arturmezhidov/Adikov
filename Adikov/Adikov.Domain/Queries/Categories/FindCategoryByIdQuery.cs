using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.Categories
{
    public class FindCategoryByIdQueryResult
    {
        public Category Category { get; set; }
    }

    public class FindCategoryByIdQuery : Query<IdCriterion, FindCategoryByIdQueryResult>
    {
        protected override FindCategoryByIdQueryResult OnExecuting(IdCriterion criterion)
        {
            Category item = DataContext.Categories.Find(criterion.Id);

            FindCategoryByIdQueryResult result = new FindCategoryByIdQueryResult
            {
                Category = item
            };

            return result;
        }
    }
}