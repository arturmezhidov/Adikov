using Adikov.Domain.Data;
using Adikov.Infrastructura.Criterion;
using Adikov.Infrastructura.Queries;

namespace Adikov.Domain.Queries
{
    public abstract class Query<TCriterion, TResponse> : QueryBase<TCriterion, TResponse> where TCriterion : ICriterion where TResponse : class 
    {
        protected ApplicationDbContext DataContext { get; }

        protected Query()
        {
            DataContext = ApplicationDbContext.Create();
        }
    }
}