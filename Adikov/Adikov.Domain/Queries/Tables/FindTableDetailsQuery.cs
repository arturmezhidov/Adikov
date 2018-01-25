using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.Tables
{
    public class TableDetailsCriterion : IdCriterion
    {
        public bool IsPreview { get; set; }

        public TableDetailsCriterion(int id) : base(id) { }
    }

    public class FindTableDetailsQueryResult
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Column> Columns { get; set; }
    }

    public class FindTableDetailsQuery : Query<TableDetailsCriterion, FindTableDetailsQueryResult>
    {
        protected override FindTableDetailsQueryResult OnExecuting(TableDetailsCriterion criterion)
        {
            Table table = DataContext.Tables.Find(criterion.Id);
            List<Column> columns = DataContext.Columns.ToList();

            if (table == null)
            {
                return null;
            }

            FindTableDetailsQueryResult result = new FindTableDetailsQueryResult
            {
                Id = table.Id,
                Name = table.Name,
                Columns = ((criterion.IsPreview
                    ? columns.Where(c => !c.IsDeleted)
                    : columns).Where(c => table.TableColumns.Any(tc => tc.ColumnId == c.Id))
                ).ToList()
            };

            return result;
        }
    }
}