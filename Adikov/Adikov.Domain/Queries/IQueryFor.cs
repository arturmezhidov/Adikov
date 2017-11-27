using System.Linq;
using Adikov.Domain.Criterion;

namespace Adikov.Domain.Queries
{
    public interface IQueryFor<out TEntity>
    {
        TEntity With<TCriterion>(TCriterion criterion) where TCriterion : ICriterion;

        IQueryable<TEntity> WithAll<TCriterion>(TCriterion criterion) where TCriterion : ICriterion;

        TEntity ById(object id);

        IQueryable<TEntity> All();
    }
}