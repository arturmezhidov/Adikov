using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.FaqItems
{
    public class FaqItemCategory
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsPublish { get; set; }

        public bool IsDeleted { get; set; }

        public IEnumerable<FaqItem> Items { get; set; }
    }

    public class GetAllFaqItemsQueryResult
    {
        public List<FaqItemCategory> ActiveItems { get; set; }

        public List<FaqItem> DeletedItems { get; set; }
    }

    public class GetAllFaqItemsQuery : Query<EmptyCriterion, GetAllFaqItemsQueryResult>
    {
        protected override GetAllFaqItemsQueryResult OnExecuting(EmptyCriterion criterion)
        {
            var items = DataContext.FaqItems.GroupBy(i => i.FaqCategory).ToList();

            GetAllFaqItemsQueryResult result = new GetAllFaqItemsQueryResult
            {
                ActiveItems = new List<FaqItemCategory>(),
                DeletedItems = new List<FaqItem>()
            };

            items.ForEach(group =>
            {
                if (group.Any())
                {
                    var activeItems = group.Where(i => !i.IsDeleted).ToList();
                    var deletedItems = group.Where(i => i.IsDeleted).ToList();

                    if (activeItems.Any())
                    {
                        result.ActiveItems.Add(new FaqItemCategory
                        {
                            Id = group.Key.Id,
                            Title = group.Key.Name,
                            IsPublish = group.Key.IsPublished,
                            IsDeleted = group.Key.IsDeleted,
                            Items = activeItems
                        });
                    }

                    if (deletedItems.Any())
                    {
                        result.DeletedItems.AddRange(deletedItems);
                    }
                }
            });

            return result;
        }
    }
}