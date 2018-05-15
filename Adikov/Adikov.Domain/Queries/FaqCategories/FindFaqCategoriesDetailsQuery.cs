using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.FaqCategories
{
    public class FaqCategoryDetails
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsPublished { get; set; }

        public int ItemsCount { get; set; }
    }

    public class FindFaqCategoriesDetailsQueryResult
    {
        public IEnumerable<FaqCategoryDetails> Categories { get; set; }

        public IEnumerable<FaqCategoryDetails> DeletedCategories { get; set; }
    }

    public class FindFaqCategoriesDetailsQuery : Query<EmptyCriterion, FindFaqCategoriesDetailsQueryResult>
    {
        protected override FindFaqCategoriesDetailsQueryResult OnExecuting(EmptyCriterion criterion)
        {
            List<FaqCategory> items = DataContext
                .FaqCategories
                .AsNoTracking()
                .Include(i => i.FaqItems)
                .ToList();

            FindFaqCategoriesDetailsQueryResult result = new FindFaqCategoriesDetailsQueryResult
            {
                Categories = items.Where(i => !i.IsDeleted).Select(ToDetailsModel),
                DeletedCategories = items.Where(i => i.IsDeleted).Select(ToDetailsModel)
            };

            return result;
        }

        protected FaqCategoryDetails ToDetailsModel(FaqCategory category)
        {
            return new FaqCategoryDetails
            {
                Id = category.Id,
                Name = category.Name,
                IsPublished = category.IsPublished,
                ItemsCount = category.FaqItems?.Count ?? 0
            };
        }
    }
}