using Adikov.Infrastructura.Criterion;
using Adikov.Infrastructura.Security;

namespace Adikov.Infrastructura.Queries
{
    public abstract class QueryBase<TCriterion, TResponse> : IQuery<TCriterion, TResponse> where TCriterion : ICriterion where TResponse : class
    {
        private UserContext userContext;

        protected UserContext UserContext => userContext ?? (userContext = new UserContext());

        public TResponse Execute(TCriterion criterion)
        {
            return OnExecuting(criterion);
        }

        protected abstract TResponse OnExecuting(TCriterion criterion);
    }
}