using System;
using System.Web.Mvc;
using Adikov.Models;
using Adikov.Platform.Configuration;
using Adikov.Services;

namespace Adikov.Controllers
{
    public abstract class LayoutController : BaseController
    {
        private const string layoutContextKey = "LayoutContext";
        private LayoutContext layoutContext;
        private ISidebarService sidebarService;
        private IMenuService menuService;

        protected LayoutContext LayoutContext
        {
            get
            {
                if (layoutContext == null)
                {
                    layoutContext = InitLayoutContext();
                }

                return layoutContext;
            }
        }

        protected ISidebarService SidebarService
        {
            get
            {
                if (sidebarService == null)
                {
                    sidebarService = new SidebarService(UserContext, Query);
                }

                return sidebarService;
            }
        }

        protected IMenuService MenuService
        {
            get
            {
                if (menuService == null)
                {
                    menuService = new MenuService(Query);
                }

                return menuService;
            }
        }

        protected new ActionResult View()
        {
            ViewData[layoutContextKey] = LayoutContext;
            return base.View();
        }

        protected new ActionResult View(object model)
        {
            ViewData[layoutContextKey] = LayoutContext;
            return base.View(model);
        }

        protected new ActionResult View(string viewName)
        {
            ViewData[layoutContextKey] = LayoutContext;
            return base.View(viewName);
        }

        protected new ActionResult View(string viewName, object model)
        {
            ViewData[layoutContextKey] = LayoutContext;
            return base.View(viewName, model);
        }

        protected virtual LayoutContext InitLayoutContext(LayoutContext context = null)
        {
            if (context == null)
            {
                context = new LayoutContext();
            }

            context.User = UserContext;
            context.LogoUrl = PlatformConfiguration.LogoPath;
            context.Sidebar = SidebarService.CreateContext();
            context.Menu = MenuService.CreateContext();
            context.ActionName = (String)RouteData.Values["action"];
            context.ContollerName = (String)RouteData.Values["controller"];

            return context;
        }

        protected virtual ActionResult Redirect(string redirectUrl, string defaultUrl)
        {
            if (String.IsNullOrEmpty(redirectUrl))
            {
                return Redirect(defaultUrl);
            }

            return Redirect(redirectUrl);
        }
    }
}