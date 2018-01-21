using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.Tables
{
    public class FindTableEditQueryResult
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Column> Columns { get; set; }

        public List<Column> AllColumns { get; set; }
    }

    public class FindTableEditQuery : Query<IdCriterion, FindTableEditQueryResult>
    {
        protected override FindTableEditQueryResult OnExecuting(IdCriterion criterion)
        {
            Table item = DataContext.Tables.Find(criterion.Id);

            if (item == null)
            {
                return null;
            }

            FindTableEditQueryResult result = new FindTableEditQueryResult
            {
                Id = item.Id,
                Name = item.Name,
                Columns = item.Columns.ToList(),
                AllColumns = DataContext.Columns.Where(i => !i.IsDeleted).ToList()
            };

            result.AllColumns.AddRange(result.Columns.Where(i => i.IsDeleted));

            return result;
        }
    }
}