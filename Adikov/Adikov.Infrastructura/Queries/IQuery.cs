using Adikov.Infrastructura.Criterion;

namespace Adikov.Infrastructura.Queries
{
    public interface IQuery<in TCriterion, out TResponse> where TCriterion : ICriterion
    {
        TResponse Execute(TCriterion criterion);
    }
}