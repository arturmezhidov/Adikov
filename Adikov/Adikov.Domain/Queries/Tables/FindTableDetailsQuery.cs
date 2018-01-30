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


    public class TableColumnDetail
    {
        public Column Column { get; set; }

        public TableColumn TableColumn { get; set; }
    }

    public class FindTableDetailsQueryResult
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<TableColumnDetail> Columns { get; set; }
    }

    public class FindTableDetailsQuery : Query<TableDetailsCriterion, FindTableDetailsQueryResult>
    {
        protected override FindTableDetailsQueryResult OnExecuting(TableDetailsCriterion criterion)
        {
            Table table = DataContext.Tables.Find(criterion.Id);
  
            if (table == null)
            {
                return null;
            }

            List<TableColumn> tableColumns = table.TableColumns.OrderBy(i => i.SortNumber).ToList();
            List<Column> columns = DataContext.Columns.Where(i => !(i.IsDeleted && criterion.IsPreview)).ToList();

            FindTableDetailsQueryResult result = new FindTableDetailsQueryResult
            {
                Id = table.Id,
                Name = table.Name,
                Columns = tableColumns.Select(i => new TableColumnDetail
                {
                    TableColumn = i,
                    Column = columns.FirstOrDefault(c => c.Id == i.ColumnId)
                }).ToList()
            };

            return result;
        }
    }
}