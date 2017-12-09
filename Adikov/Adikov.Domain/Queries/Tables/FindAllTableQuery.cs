using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.Tables
{
    public class FindAllTableQueryResult
    {
        public IEnumerable<Table> ActiveTables { get; set; }

        public IEnumerable<Table> DeletedTables { get; set; }
    }

    public class FindAllTableQuery : Query<EmptyCriterion, FindAllTableQueryResult>
    {
        protected override FindAllTableQueryResult OnExecuting(EmptyCriterion criterion)
        {
            List<Table> items = DataContext.Tables.AsNoTracking().ToList();

            FindAllTableQueryResult result = new FindAllTableQueryResult
            {
                ActiveTables = items.Where(i => !i.IsDeleted),
                DeletedTables = items.Where(i => i.IsDeleted)
            };

            return result;
        }
    }
}