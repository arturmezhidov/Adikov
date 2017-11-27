using Adikov.Domain.Criterion;

namespace Adikov.Domain.Queries
{
    public interface IQuery<in TCriterion, out TResult> where TCriterion : ICriterion
    {
        TResult Execute(TCriterion criterion);
    }
}