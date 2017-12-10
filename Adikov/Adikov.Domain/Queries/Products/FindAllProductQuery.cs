using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.Products
{
    public class FindAllProductQueryResult
    {
        public List<Product> ActiveProducts { get; set; }

        public List<Product> DeletedProducts { get; set; }
    }

    public class FindAllProductQuery : Query<EmptyCriterion, FindAllProductQueryResult>
    {
        protected override FindAllProductQueryResult OnExecuting(EmptyCriterion criterion)
        {
            List<Product> items = DataContext.Products.AsNoTracking().ToList();

            FindAllProductQueryResult result = new FindAllProductQueryResult
            {
                ActiveProducts = items.Where(i => !i.IsDeleted).OrderBy(i => i.Category.Name).ToList(),
                DeletedProducts = items.Where(i => i.IsDeleted).OrderBy(i => i.Category.Name).ToList()
            };

            return result;
        }
    }
}