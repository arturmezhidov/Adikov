using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.Rows
{
    public class FindRowByIdQueryResult
    {
        public Row Row { get; set; }
    }

    public class FindRowByIdQuery : Query<IdCriterion, FindRowByIdQueryResult>
    {
        protected override FindRowByIdQueryResult OnExecuting(IdCriterion criterion)
        {
            Row item = DataContext.Rows.Find(criterion.Id);

            FindRowByIdQueryResult result = new FindRowByIdQueryResult
            {
                Row = item
            };

            return result;
        }
    }
}