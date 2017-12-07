using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.Columns
{
    public class FindActiveColumnQueryResult
    {
        public List<Column> ActiveColumns { get; set; }
    }

    public class FindActiveColumnQuery : Query<EmptyCriterion, FindActiveColumnQueryResult>
    {
        protected override FindActiveColumnQueryResult OnExecuting(EmptyCriterion criterion)
        {
            FindActiveColumnQueryResult result = new FindActiveColumnQueryResult
            {
                ActiveColumns = DataContext.Columns.AsNoTracking().Where(i => !i.IsDeleted).ToList()
            };

            return result;
        }
    }
}