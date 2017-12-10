using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.Categories
{
    public class FindCategoryByTypeCriterion : ICriterion
    {
        public CategoryType Type { get; set; }

        public FindCategoryByTypeCriterion(CategoryType type)
        {
            Type = type;
        }
    }

    public class FindCategoryByTypeQueryResult
    {
        public List<Category> Categories { get; set; }
    }

    public class FindCategoryByTypeQuery : Query<FindCategoryByTypeCriterion, FindCategoryByTypeQueryResult>
    {
        protected override FindCategoryByTypeQueryResult OnExecuting(FindCategoryByTypeCriterion criterion)
        {
            FindCategoryByTypeQueryResult result = new FindCategoryByTypeQueryResult
            {
                Categories = DataContext.Categories.AsNoTracking().Where(i => i.Type == criterion.Type).ToList()
        };

            return result;
        }
    }
}