using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Criterion;
using Adikov.Domain.Models;

namespace Adikov.Domain.Queries
{
    public class FindAllProductCategoryQueryResult
    {
        public IEnumerable<ProductCategory> ActiveCategories { get; set; }

        public IEnumerable<ProductCategory> DeletedCategories { get; set; }
    }

    public class FindAllProductCategoryQuery : Query<EmptyCriterion, FindAllProductCategoryQueryResult>
    {
        protected override FindAllProductCategoryQueryResult OnExecuting(EmptyCriterion criterion)
        {
            List<ProductCategory> categories = DataContext.ProductCategories.AsNoTracking().ToList();

            FindAllProductCategoryQueryResult result = new FindAllProductCategoryQueryResult
            {
                ActiveCategories = categories.Where(i => !i.IsDeleted),
                DeletedCategories = categories.Where(i => i.IsDeleted)
            };

            return result;
        }
    }
}