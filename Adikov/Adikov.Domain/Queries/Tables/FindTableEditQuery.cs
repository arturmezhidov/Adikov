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
            Table table = DataContext.Tables.Find(criterion.Id);
            List<Column> columns = DataContext.Columns.ToList();

            if (table == null)
            {
                return null;
            }

            FindTableEditQueryResult result = new FindTableEditQueryResult
            {
                Id = table.Id,
                Name = table.Name,
                Columns = columns.Where(i => table.TableColumns.Any(tc => tc.ColumnId == i.Id)).ToList(),
                AllColumns = columns.Where(i => !i.IsDeleted).ToList()
            };

            result.AllColumns.AddRange(result.Columns.Where(i => i.IsDeleted));

            return result;
        }
    }
}