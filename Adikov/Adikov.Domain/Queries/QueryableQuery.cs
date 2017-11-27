using System.Linq;
using Adikov.Domain.Criterion;

namespace Adikov.Domain.Queries
{
    public abstract class QueryableQuery<TCriterion, TEntity> : Query<TCriterion, IQueryable<TEntity>, TEntity>, IQueryableQuery<TCriterion, TEntity>
        where TCriterion : ICriterion
        where TEntity : class
    {
    }
}