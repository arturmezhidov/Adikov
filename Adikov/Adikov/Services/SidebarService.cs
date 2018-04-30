using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
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
            ISidebarContext context = new SidebarContext
            {
                Groups = GetSidebarItems()
            };

            CheckActiveItem(context);

            return context;
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
                GetFaqItem(),
                new SidebarGroup
                {
                    Text = "Контакты",
                    Icon = "icon-call-end",
                    ViewLink = "/Contacts"
                },
                new SidebarGroup
                {
                    Text = "Об организации",
                    Icon = "icon-info",
                    ViewLink = "/About"
                }
            };
        }

        protected SidebarGroup GetFaqItem()
        {
            SidebarGroup item = new SidebarGroup
            {
                Text = "FAQ",
                Icon = "icon-question",
                ViewLink = "/Faq"
            };

            if (UserContext.IsAdmin)
            {
                item.ViewLink = null;

                item.Items = new List<SidebarItem>
                {
                    new SidebarItem
                    {
                        Text = "Предпросмотр",
                        ViewLink = "/Faq"
                    },
                    new SidebarItem
                    {
                        Text = "Категории",
                        ViewLink = "/FaqCategory"
                    },
                    new SidebarItem
                    {
                        Text = "Ответы",
                        ViewLink = "/FaqItem"
                    },
                    new SidebarItem
                    {
                        Text = "Добавить ответ",
                        ViewLink = "/FaqItem/Add"
                    },
                    new SidebarItem
                    {
                        Text = "Запросы",
                        ViewLink = "/FaqRequest"
                    }
                };
            }

            return item;
        }

        protected IEnumerable<SidebarGroup> GetProductItems()
        {
            GetNavigateItemsQueryResult result = Query.For<GetNavigateItemsQueryResult>().With(new EmptyCriterion());

            return result.Groups.Select(ToSidebarGroup).Where(i => i != null);
        }

        protected SidebarGroup ToSidebarGroup(Group group)
        {
            SidebarGroup sidebarGroup = new SidebarGroup
            {
                Text = group.Text,
                Icon = group.Icon,
                Items = group.Items.Select(ToSidebarItem).ToList()
            };

            if (sidebarGroup.Items.Count == 0)
            {
                if (UserContext.IsAdmin)
                {
                    sidebarGroup.ViewLink = "/Category";
                }
                else
                {
                    return null;
                }
            }
            else if (sidebarGroup.Items.Count == 1)
            {
                sidebarGroup.ViewLink = sidebarGroup.Items.First().ViewLink;
                sidebarGroup.Items.Clear();
            }

            return sidebarGroup;
        }

        protected SidebarItem ToSidebarItem(Item item)
        {
            return new SidebarItem
            {
                Text = item.Text,
                ViewLink = $"/ProductInfo/Index/{item.Id}"
            };
        }

        protected void CheckActiveItem(ISidebarContext context)
        {
            string url = HttpContext.Current.Request.RawUrl;

            foreach (SidebarGroup group in context.Groups)
            {
                if (group.Items != null && group.Items.Any())
                {
                    foreach (SidebarItem item in group.Items)
                    {
                        if (item.ViewLink == url)
                        {
                            item.IsActive = true;
                            group.IsActive = true;
                            return;
                        }
                    }
                }
                else
                {
                    if (group.ViewLink == url)
                    {
                        group.IsActive = true;
                        return;
                    }
                }
            }
        }
    }
}