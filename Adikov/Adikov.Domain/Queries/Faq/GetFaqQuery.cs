using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Adikov.Infrastructura.Criterion;
using Adikov.Domain.Models;

namespace Adikov.Domain.Queries.Faq
{
    public class GetFaqQueryResult
    {
        public IEnumerable<FaqCategory> Categories { get; set; }
    }

    public class GetFaqQuery : Query<EmptyCriterion, GetFaqQueryResult>
    {
        protected override GetFaqQueryResult OnExecuting(EmptyCriterion criterion)
        {
            var categories = DataContext
                .FaqCategories
                .Include(c => c.FaqItems)
                .Where(c => !c.IsDeleted && c.IsPublished)
                .ToList();

            categories.ForEach(category =>
            {
                if (category.FaqItems == null || !category.FaqItems.Any())
                {
                    return;
                }

                category.FaqItems = category
                    .FaqItems
                    .Where(i => !i.IsDeleted && i.IsPublished)
                    .ToList();
            });

            categories = categories
                .Where(c => c.FaqItems != null && c.FaqItems.Any())
                .ToList();

            GetFaqQueryResult result = new GetFaqQueryResult
            {
                Categories = categories
            };

            return result;
        }
    }
}