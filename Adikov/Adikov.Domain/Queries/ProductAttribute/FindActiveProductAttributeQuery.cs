using Adikov.Infrastructura.Criterion;
using System.Collections.Generic;
using System.Linq;

namespace Adikov.Domain.Queries.ProductAttribute
{
    public class FindActiveProductAttributeQueryResult
    {
        public List<Models.ProductAttribute> ActiveAttributes { get; set; }
    }

    public class FindActiveProductAttributeQuery : Query<EmptyCriterion, FindActiveProductAttributeQueryResult>
    {
        protected override FindActiveProductAttributeQueryResult OnExecuting(EmptyCriterion criterion)
        {
            FindActiveProductAttributeQueryResult result = new FindActiveProductAttributeQueryResult
            {
                ActiveAttributes = DataContext.ProductAttributes.AsNoTracking().Where(i => !i.IsDeleted).ToList()
            };

            return result;
        }
    }
}