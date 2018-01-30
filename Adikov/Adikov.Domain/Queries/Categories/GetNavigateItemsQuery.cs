using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.Categories
{
    public class Item
    {
        public int Id { get; set; }

        public string Text { get; set; }
    }

    public class Group
    {
        public string Icon { get; set; }

        public string Text { get; set; }

        public IEnumerable<Item> Items { get; set; }
    }

    public class GetNavigateItemsQueryResult
    {
        public IEnumerable<Group> Groups { get; set; }
    }

    public class GetNavigateItemsQuery : Query<EmptyCriterion, GetNavigateItemsQueryResult>
    {
        protected override GetNavigateItemsQueryResult OnExecuting(EmptyCriterion criterion)
        {
            return new GetNavigateItemsQueryResult
            {
                Groups = DataContext
                    .Categories
                    .Include(i => i.Products)
                    .Where(i => !i.IsDeleted)
                    .OrderBy(i => i.SortNumber)
                    .Select(i => new Group
                    {
                        Text = i.Name,
                        Icon = i.Icon,
                        Items = i.Products.Select(p => new Item
                        {
                            Id = p.Id,
                            Text = p.Name
                        })
                    })
            };
        }
    }
}