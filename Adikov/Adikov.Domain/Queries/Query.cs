using Adikov.Domain.Criterion;
using Adikov.Domain.Data;
using Adikov.Infrastructura.Security;

namespace Adikov.Domain.Queries
{
    public abstract class Query<TCriterion, TResult> : IQuery<TCriterion, TResult> where TCriterion : ICriterion where TResult : class 
    {
        protected ApplicationDbContext DataContext { get; }

        protected UserContext UserContext { get; }

        protected Query()
        {
            DataContext = ApplicationDbContext.Create();
            UserContext = new UserContext();
        }

        public TResult Execute(TCriterion criterion)
        {
            return OnExecuting(criterion);
        }

        protected abstract TResult OnExecuting(TCriterion criterion);
    }
}