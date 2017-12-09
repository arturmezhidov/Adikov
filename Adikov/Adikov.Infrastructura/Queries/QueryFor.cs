using System;
using System.Linq;
using System.Web.Mvc;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Infrastructura.Queries
{
    public class QueryFor<TResponse> : IQueryFor<TResponse> where TResponse : class
    {
        private readonly IDependencyResolver dependencyResolver;

        public QueryFor(IDependencyResolver dependencyResolver)
        {
            this.dependencyResolver = dependencyResolver;
        }

        public TResponse With<TCriterion>(TCriterion criterion) where TCriterion : ICriterion
        {
            IQuery<TCriterion, TResponse> query = null;

            try
            {
                query = dependencyResolver.GetService<IQuery<TCriterion, TResponse>>();
            }
            finally
            {
                if (query == null)
                {
                    throw new NotImplementedException($"Interface IQuery<{typeof(TCriterion).Name}, {typeof(TResponse).Name}> does not implement.");
                }
            }

            return query.Execute(criterion);
        }

        public TResponse ById(object id)
        {
            IQuery<IdCriterion, TResponse> query = null;

            try
            {
                query = dependencyResolver.GetService<IQuery<IdCriterion, TResponse>>();
            }
            finally
            {
                if (query == null)
                {
                    throw new NotImplementedException($"Interface IQuery<{typeof(IdCriterion).Name}, {typeof(TResponse).Name}> does not implement.");
                }
            }

            return query.Execute(new IdCriterion(id));
        }

        public IQueryable<TResponse> All()
        {
            return null;
        }
    }
}