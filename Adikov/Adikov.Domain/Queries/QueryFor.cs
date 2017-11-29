using System;
using System.Linq;
using System.Web.Mvc;
using Adikov.Domain.Criterion;

namespace Adikov.Domain.Queries
{
    public class QueryFor<TEntity> : IQueryFor<TEntity> where TEntity: class
    {
        private readonly IDependencyResolver dependencyResolver;

        public QueryFor(IDependencyResolver dependencyResolver)
        {
            this.dependencyResolver = dependencyResolver;
        }

        public TEntity With<TCriterion>(TCriterion criterion) where TCriterion : ICriterion
        {
            IQuery<TCriterion, TEntity> query = null;

            try
            {
                query = dependencyResolver.GetService<IQuery<TCriterion, TEntity>>();
            }
            finally
            {
                if (query == null)
                {
                    throw new NotImplementedException($"Interface IQuery<{typeof(TCriterion).Name}, {typeof(TEntity).Name}> does not implement.");
                }
            }

            return query.Execute(criterion);
        }

        public TEntity ById(object id)
        {
            return null;
        }

        public IQueryable<TEntity> All()
        {
            return null;
        }
    }
}