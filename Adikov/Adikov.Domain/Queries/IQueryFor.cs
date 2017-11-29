using System.Linq;
using Adikov.Domain.Criterion;

namespace Adikov.Domain.Queries
{
    public interface IQueryFor<out TResult>
    {
        TResult With<TCriterion>(TCriterion criterion) where TCriterion : ICriterion;

        TResult ById(object id);

        IQueryable<TResult> All();
    }
}