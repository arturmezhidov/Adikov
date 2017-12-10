using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.Tables
{
    public class FindActiveTableQueryResult
    {
        public List<Table> ActiveTables { get; set; }
    }

    public class FindActiveTableQuery : Query<EmptyCriterion, FindActiveTableQueryResult>
    {
        protected override FindActiveTableQueryResult OnExecuting(EmptyCriterion criterion)
        {
            FindActiveTableQueryResult result = new FindActiveTableQueryResult
            {
                ActiveTables = DataContext.Tables.AsNoTracking().Where(i => !i.IsDeleted).ToList()
            };

            return result;
        }
    }
}