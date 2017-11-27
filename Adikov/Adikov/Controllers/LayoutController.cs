using System.Collections.Generic;
using System.Web.Mvc;
using Adikov.Models;
using Adikov.Models.Sidebar;

namespace Adikov.Controllers
{
    public abstract class LayoutController : BaseController
    {
        private const string layoutContextKey = "LayoutContext";
        private LayoutContext layoutContext;

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

            context.LogoUrl = @"/Content/assets/layouts/layout2/img/logo-default.png";
            context.Sidebar = GetSidebar();
            context.User = UserContext;

            return context;
        }

        private SidebarContext GetSidebar()
        {
            var groups =  new List<SidebarGroup>
            {
                new SidebarGroup
                {
                    Text = "Трубы нержавеющие",
                    ViewLink = "/",
                    Icon = "fa fa-circle-thin",
                    Items = new List<SidebarItem>
                    {
                        new SidebarItem
                        {
                            Text = "Труба нержавеющая электросварочная",
                            ViewLink = "/"
                        },
                        new SidebarItem
                        {
                            Text = "Труба нержавеющая бесшовная",
                            ViewLink = "/"
                        }
                    }
                },
                new SidebarGroup
                {
                    Text = "Трубы профильные нержавеющие",
                    ViewLink = "/",
                    Icon = "fa fa-square-o",
                    Items = new List<SidebarItem>
                    {
                        new SidebarItem
                        {
                            Text = "Труба нержавеющая квадратная",
                            ViewLink = "/"
                        },
                        new SidebarItem
                        {
                            Text = "Труба нержавеющая прямоугольная",
                            ViewLink = "/"
                        }
                    }
                },
                new SidebarGroup
                {
                    Text = "Круги (прутки) нержавеющие",
                    ViewLink = "/",
                    Icon = "fa fa-circle"
                },
                new SidebarGroup
                {
                    Text = "Шестигранники нержавеющие",
                    ViewLink = "/",
                    Icon = "icon-settings"
                },
                new SidebarGroup
                {
                    Text = "Квадрат нержавеющий",
                    ViewLink = "/",
                    Icon = "fa fa-square"
                },
                new SidebarGroup
                {
                    Text = "Листы нержавеющие",
                    ViewLink = "/",
                    Icon = "icon-layers"
                },
                new SidebarGroup
                {
                    Text = "Уголки нержавеющие",
                    ViewLink = "/",
                    Icon = "icon-frame"
                },
                new SidebarGroup
                {
                    Text = "Проволока нержавеющая",
                    ViewLink = "/",
                    Icon = "fa fa-forumbee"
                },
                new SidebarGroup
                {
                    Text = "Трубопроводная арматура",
                    ViewLink = "/",
                    Icon = "icon-graph",
                    Items = new List<SidebarItem>
                    {
                        new SidebarItem
                        {
                            Text = "Отводы",
                            ViewLink = "/"
                        },
                        new SidebarItem
                        {
                            Text = "Фланцы",
                            ViewLink = "/"
                        },
                        //new SidebarItem
                        //{
                        //    Text = "Переходники",
                        //    ViewLink = "/"
                        //},
                        new SidebarItem
                        {
                            Text = "Краны нержавеющие",
                            ViewLink = "/"
                        },
                        new SidebarItem
                        {
                            Text = "Тройники нержавеющие",
                            ViewLink = "/"
                        }
                    }
                },
                new SidebarGroup
                {
                    Text = "Администрирование",
                    ViewLink = "/",
                    Icon = "icon-settings",
                    Items = new List<SidebarItem>
                    {
                        new SidebarItem
                        {
                            Text = "Категории",
                            ViewLink = "/ProductCategory"
                        },
                        new SidebarItem
                        {
                            Text = "Атрибуты",
                            ViewLink = "/ProductAttribute"
                        }
                    }
                },
                new SidebarGroup
                {
                    Text = "Контакты",
                    ViewLink = "/",
                    Icon = "icon-call-end"
                },
                new SidebarGroup
                {
                    Text = "Об организации",
                    ViewLink = "/",
                    Icon = "icon-info"
                },
                new SidebarGroup
                {
                    Text = "Услуги",
                    ViewLink = "/",
                    Icon = "icon-calculator"
                }
            };

            return new SidebarContext
            {
                Groups = groups
            };
        }
    }
}