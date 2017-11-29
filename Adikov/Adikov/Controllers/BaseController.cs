using System.Web.Mvc;
using Adikov.Domain.Commands;
using Adikov.Domain.Queries;
using Adikov.Infrastructura.Security;

namespace Adikov.Controllers
{
    public abstract class BaseController : Controller
    {
        protected IQueryBuilder Query { get; }

        protected ICommandBuilder Command { get; }

        protected IUserContext UserContext { get; }

        protected BaseController()
        {
            Query = new QueryBuilder(DependencyResolver.Current);
            Command = new CommandBuilder(DependencyResolver.Current);
            UserContext = new UserContext();
        }
    }
}