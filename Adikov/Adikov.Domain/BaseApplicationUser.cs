using System.Web.Mvc;
using Adikov.Infrastructura.Queries;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Adikov.Domain
{
    public abstract class BaseApplicationUser : IdentityUser
    {
        protected IQueryBuilder Query { get; }

        protected BaseApplicationUser()
        {
            Query = new QueryBuilder(DependencyResolver.Current);
        }
    }
}