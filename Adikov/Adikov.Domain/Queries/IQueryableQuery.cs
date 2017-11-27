using System.Linq;
using Adikov.Domain.Criterion;

namespace Adikov.Domain.Queries
{
    public interface IQueryableQuery<in TCriterion, out TEntity> : IQuery<TCriterion, IQueryable<TEntity>> where TCriterion : ICriterion
    {
    }
}