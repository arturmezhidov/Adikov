using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.FaqCategories
{
    public class FindFaqCategoriesQueryResult
    {
        public IEnumerable<FaqCategory> Categories { get; set; }
    }

    public class FindFaqCategoriesQuery : Query<EmptyCriterion, FindFaqCategoriesQueryResult>
    {
        protected override FindFaqCategoriesQueryResult OnExecuting(EmptyCriterion criterion)
        {
            List<FaqCategory> items = DataContext
                .FaqCategories
                .AsNoTracking()
                .Where(i => !i.IsDeleted)
                .ToList();

            FindFaqCategoriesQueryResult result = new FindFaqCategoriesQueryResult
            {
                Categories = items
            };

            return result;
        }
    }
}