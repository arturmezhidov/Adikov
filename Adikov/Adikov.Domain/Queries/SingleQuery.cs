using Adikov.Domain.Criterion;

namespace Adikov.Domain.Queries
{
    public abstract class SingleQuery<TCriterion, TEntity> : Query<TCriterion, TEntity, TEntity>
        where TCriterion : ICriterion
        where TEntity : class
    {
    }
}