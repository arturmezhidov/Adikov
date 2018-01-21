using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.Categories
{
    public class FindAllCategoryCanAddProductQueryResult
    {
        public List<Category> Categories { get; set; }
    }

    public class FindAllCategoryCanAddProductQuery : Query<EmptyCriterion, FindAllCategoryCanAddProductQueryResult>
    {
        protected override FindAllCategoryCanAddProductQueryResult OnExecuting(EmptyCriterion criterion)
        {
            FindAllCategoryCanAddProductQueryResult result = new FindAllCategoryCanAddProductQueryResult
            {
                Categories = DataContext
                    .Categories
                    .AsNoTracking()
                    .Include(i => i.Products)
                    .ToList()
                    .Where(i => !(i.Type == CategoryType.Single && i.Products.Any()))
                    .OrderBy(i => i.SortNumber)
                    .ToList()
            };

            return result;
        }
    }
}