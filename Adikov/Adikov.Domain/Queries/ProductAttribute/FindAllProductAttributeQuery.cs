using System.Collections.Generic;
using System.Linq;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.ProductAttribute
{
    public class FindAllProductAttributeQueryResult
    {
        public IEnumerable<Models.ProductAttribute> ActiveAttributes { get; set; }

        public IEnumerable<Models.ProductAttribute> DeletedAttributes { get; set; }
    }

    public class FindAllProductAttributeQuery : Query<EmptyCriterion, FindAllProductAttributeQueryResult>
    {
        protected override FindAllProductAttributeQueryResult OnExecuting(EmptyCriterion criterion)
        {
            List<Models.ProductAttribute> items = DataContext.ProductAttributes.AsNoTracking().ToList();

            FindAllProductAttributeQueryResult result = new FindAllProductAttributeQueryResult
            {
                ActiveAttributes = items.Where(i => !i.IsDeleted),
                DeletedAttributes = items.Where(i => i.IsDeleted)
            };

            return result;
        }
    }
}