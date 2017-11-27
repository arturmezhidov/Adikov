using System.Linq;
using Adikov.Domain.Criterion;

namespace Adikov.Domain.Queries
{
    public class FindAllQuery<TEntity> : QueryableQuery<EmptyCriterion, TEntity> where TEntity : class
    {
        protected override IQueryable<TEntity> OnExecuting(EmptyCriterion criterion)
        {
            return Entities.AsNoTracking().AsQueryable();
        }
    }
}