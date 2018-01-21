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
            Table item = DataContext.Tables.Find(criterion.Id);

            if (item == null)
            {
                return null;
            }

            FindTableDetailsQueryResult result = new FindTableDetailsQueryResult
            {
                Id = item.Id,
                Name = item.Name,
                Columns = (criterion.IsPreview 
                    ? item.Columns.Where(i => !i.IsDeleted) 
                    : item.Columns
                ).ToList()
            };

            return result;
        }
    }
}