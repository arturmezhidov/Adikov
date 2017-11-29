using System.Web.Mvc;

namespace Adikov.Domain.Queries
{
    public class QueryBuilder : IQueryBuilder
    {
        private readonly IDependencyResolver dependencyResolver;

        public QueryBuilder(IDependencyResolver dependencyResolver)
        {
            this.dependencyResolver = dependencyResolver;
        }

        public IQueryFor<TResult> For<TResult>() where TResult : class
        {
            return new QueryFor<TResult>(dependencyResolver);
        }
    }
}