using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.Categories
{
    public class FindAllCategoryQueryResult
    {
        public IEnumerable<Category> ActiveCategories { get; set; }

        public IEnumerable<Category> DeletedCategories { get; set; }
    }

    public class FindAllCategoryQuery : Query<EmptyCriterion, FindAllCategoryQueryResult>
    {
        protected override FindAllCategoryQueryResult OnExecuting(EmptyCriterion criterion)
        {
            List<Category> categories = DataContext.Categories.AsNoTracking().ToList();

            FindAllCategoryQueryResult result = new FindAllCategoryQueryResult
            {
                ActiveCategories = categories.Where(i => !i.IsDeleted),
                DeletedCategories = categories.Where(i => i.IsDeleted)
            };

            return result;
        }
    }
}