using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.FaqItems
{
    public class FaqItemCategory
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsPublish { get; set; }

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
            var categories = DataContext
                .FaqCategories
                .Include(i => i.FaqItems)
                .Where(i => !i.IsDeleted)
                .ToList();

            GetAllFaqItemsQueryResult result = new GetAllFaqItemsQueryResult
            {
                ActiveItems = new List<FaqItemCategory>(),
                DeletedItems = new List<FaqItem>()
            };

            categories.ForEach(category =>
            {
                if(category.FaqItems == null)
                {
                    category.FaqItems = new List<FaqItem>();
                }

                var activeItems = category.FaqItems.Where(i => !i.IsDeleted).ToList();
                var deletedItems = category.FaqItems.Where(i => i.IsDeleted).ToList();

                result.ActiveItems.Add(new FaqItemCategory
                {
                    Id = category.Id,
                    Title = category.Name,
                    IsPublish = category.IsPublished,
                    Items = activeItems
                });

                if (deletedItems.Any())
                {
                    result.DeletedItems.AddRange(deletedItems);
                }
            });

            return result;
        }
    }
}