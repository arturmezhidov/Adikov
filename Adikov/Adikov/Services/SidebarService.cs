using System;
using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Queries.Categories;
using Adikov.Infrastructura.Criterion;
using Adikov.Infrastructura.Queries;
using Adikov.Infrastructura.Security;
using Adikov.Models.Sidebar;

namespace Adikov.Services
{
    public interface ISidebarService
    {
        ISidebarContext CreateContext();

        IEnumerable<SidebarGroup> GetSidebarItems();
    }

    public class SidebarService : ISidebarService
    {
        protected IUserContext UserContext { get; }

        protected IQueryBuilder Query { get; }

        public SidebarService(IUserContext userContext, IQueryBuilder query)
        {
            UserContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
            Query = query ?? throw new ArgumentNullException(nameof(query));
        }

        public ISidebarContext CreateContext()
        {
            return new SidebarContext
            {
                Groups = GetSidebarItems()
            };
        }

        public IEnumerable<SidebarGroup> GetSidebarItems()
        {
            List<SidebarGroup> items = new List<SidebarGroup>();

            if (UserContext.IsAdmin)
            {
                items.AddRange(GetAdminItems());
            }

            items.AddRange(GetProductItems());
            items.AddRange(GetCommonItems());

            return items;
        }

        protected IEnumerable<SidebarGroup> GetAdminItems()
        {
            return new List<SidebarGroup>
            {
                new SidebarGroup
                {
                    Text = "Шаблоны",
                    ViewLink = "/",
                    Icon = "fa fa-puzzle-piece",
                    Items = new List<SidebarItem>
                    {
                        new SidebarItem
                        {
                            Text = "Столбцы",
                            ViewLink = "/Column"
                        },
                        new SidebarItem
                        {
                            Text = "Таблицы",
                            ViewLink = "/Table"
                        }
                    }
                },
                new SidebarGroup
                {
                    Text = "Продукция",
                    ViewLink = "/",
                    Icon = "fa fa-cubes",
                    Items = new List<SidebarItem>
                    {
                        new SidebarItem
                        {
                            Text = "Категории",
                            ViewLink = "/Category"
                        },
                        new SidebarItem
                        {
                            Text = "Продукты",
                            ViewLink = "/Product"
                        }
                    }
                }
            };
        }

        protected IEnumerable<SidebarGroup> GetCommonItems()
        {
            return new List<SidebarGroup>
            {
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
        }

        protected IEnumerable<SidebarGroup> GetProductItems()
        {
            GetNavigateItemsQueryResult result = Query.For<GetNavigateItemsQueryResult>().With(new EmptyCriterion());
            return result
                .Groups
                .Select(g => new SidebarGroup
                {
                    Text = g.Text,
                    Icon = g.Icon,
                    ViewLink = g.Items.Any() ? "/" : null,
                    Items = g.Items.Select(i => new SidebarItem
                    {
                        Text = i.Text
                    }).ToList()
                });
        }
    }
}