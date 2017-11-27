using System.Web.Mvc;
using Adikov.Domain.Queries;
using Adikov.Infrastructura.Security;

namespace Adikov.Controllers
{
    public abstract class BaseController : Controller
    {
        protected IQueryBuilder Query { get; }

        protected IUserContext UserContext { get; }

        protected BaseController()
        {
            Query = new QueryBuilder(DependencyResolver.Current);
            UserContext = new UserContext();
        }
    }
}