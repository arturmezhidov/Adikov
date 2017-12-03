using System.Linq;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Infrastructura.Queries
{
    public interface IQueryableQuery<in TCriterion, out TResponse> : IQuery<TCriterion, IQueryable<TResponse>> where TCriterion : ICriterion
    {
    }
}