using System.Linq;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Infrastructura.Queries
{
    public interface IQueryFor<out TResponse>
    {
        TResponse With<TCriterion>(TCriterion criterion) where TCriterion : ICriterion;

        TResponse ById(object id);

        IQueryable<TResponse> All();
    }
}