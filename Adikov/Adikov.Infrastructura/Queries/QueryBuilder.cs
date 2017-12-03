using System.Web.Mvc;

namespace Adikov.Infrastructura.Queries
{
    public class QueryBuilder : IQueryBuilder
    {
        private readonly IDependencyResolver dependencyResolver;

        public QueryBuilder(IDependencyResolver dependencyResolver)
        {
            this.dependencyResolver = dependencyResolver;
        }

        public IQueryFor<TResponse> For<TResponse>() where TResponse : class
        {
            return new QueryFor<TResponse>(dependencyResolver);
        }
    }
}