using Adikov.Domain.Criterion;

namespace Adikov.Domain.Queries
{
    public class FindByIdQuery<TEntity> : SingleQuery<IdCriterion, TEntity> where TEntity : class
    {
        protected override TEntity OnExecuting(IdCriterion criterion)
        {
            return Entities.Find(criterion.Id);
        }
    }
}