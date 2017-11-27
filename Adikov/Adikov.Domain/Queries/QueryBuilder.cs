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

        public IQueryFor<TEntity> For<TEntity>() where TEntity : class
        {
            return new QueryFor<TEntity>(dependencyResolver);
        }
    }
}