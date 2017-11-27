using System.Data.Entity;
using Adikov.Domain.Criterion;
using Adikov.Domain.Data;
using Adikov.Infrastructura.Security;

namespace Adikov.Domain.Queries
{
    public abstract class Query<TCriterion, TResult, TEntity> : IQuery<TCriterion, TResult> 
        where TCriterion : ICriterion 
        where TResult : class 
        where TEntity : class
    {
        protected ApplicationDbContext DataContext { get; }

        protected UserContext UserContext { get; }

        protected DbSet<TEntity> Entities { get; }

        protected Query()
        {
            DataContext = ApplicationDbContext.Create();
            Entities = DataContext.Set<TEntity>();
            UserContext = new UserContext();
        }

        public TResult Execute(TCriterion criterion)
        {
            return OnExecuting(criterion);
        }

        protected abstract TResult OnExecuting(TCriterion criterion);
    }
}