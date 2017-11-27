using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Adikov.App_Start;
using Castle.Windsor;

namespace Adikov
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new WindsorContainer();
            container.Install(new WindsorInstaller());
            DependencyResolver.SetResolver(new WindsorDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}