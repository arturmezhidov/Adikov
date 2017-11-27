using Adikov.Domain.Criterion;

namespace Adikov.Domain.Queries
{
    public interface IFindByIdQuery<in TCriterion, out TEntity> : IQuery<TCriterion, TEntity> where TCriterion : ICriterion
    {
    }
}