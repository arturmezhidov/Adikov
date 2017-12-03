using System.Collections.Generic;
using System.Linq;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.ProductCategory
{
    public class FindAllProductCategoryQueryResult
    {
        public IEnumerable<Models.ProductCategory> ActiveCategories { get; set; }

        public IEnumerable<Models.ProductCategory> DeletedCategories { get; set; }
    }

    public class FindAllProductCategoryQuery : Query<EmptyCriterion, FindAllProductCategoryQueryResult>
    {
        protected override FindAllProductCategoryQueryResult OnExecuting(EmptyCriterion criterion)
        {
            List<Models.ProductCategory> categories = DataContext.ProductCategories.AsNoTracking().ToList();

            FindAllProductCategoryQueryResult result = new FindAllProductCategoryQueryResult
            {
                ActiveCategories = categories.Where(i => !i.IsDeleted),
                DeletedCategories = categories.Where(i => i.IsDeleted)
            };

            return result;
        }
    }
}