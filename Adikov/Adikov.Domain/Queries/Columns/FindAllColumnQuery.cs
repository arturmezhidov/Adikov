using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.Columns
{
    public class FindAllColumnQueryResult
    {
        public IEnumerable<Column> ActiveColumns { get; set; }

        public IEnumerable<Column> DeletedColumns { get; set; }
    }

    public class FindAllColumnQuery : Query<EmptyCriterion, FindAllColumnQueryResult>
    {
        protected override FindAllColumnQueryResult OnExecuting(EmptyCriterion criterion)
        {
            List<Column> items = DataContext.Columns.AsNoTracking().ToList();

            FindAllColumnQueryResult result = new FindAllColumnQueryResult
            {
                ActiveColumns = items.Where(i => !i.IsDeleted),
                DeletedColumns = items.Where(i => i.IsDeleted)
            };

            return result;
        }
    }
}