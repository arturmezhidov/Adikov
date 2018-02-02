using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.Categories
{
    public class CategoryDetails
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Icon { get; set; }

        public string Name { get; set; }

        public int FileId { get; set; }

        public File File { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public bool HasProducts { get; set; }
    }

    public class FindAllCategoryDetailsQueryResult
    {
        public List<CategoryDetails> ActiveCategories { get; set; }

        public List<CategoryDetails> DeletedCategories { get; set; }
    }

    public class FindAllCategoryDetailsQuery : Query<EmptyCriterion, FindAllCategoryDetailsQueryResult>
    {
        protected override FindAllCategoryDetailsQueryResult OnExecuting(EmptyCriterion criterion)
        {
            List<Category> categories = DataContext.Categories.Include(i => i.Products).AsNoTracking().ToList();

            FindAllCategoryDetailsQueryResult result = new FindAllCategoryDetailsQueryResult
            {
                ActiveCategories = categories.Where(i => !i.IsDeleted).OrderBy(i => i.SortNumber).Select(GetDetails).ToList(),
                DeletedCategories = categories.Where(i => i.IsDeleted).OrderBy(i => i.SortNumber).Select(GetDetails).ToList()
            };

            return result;
        }

        protected CategoryDetails GetDetails(Category category)
        {
            return new CategoryDetails
            {
                Id = category.Id,
                Name = category.Name,
                Icon = category.Icon,
                File = category.File,
                FileId = category.FileId,
                IsDeleted = category.IsDeleted,
                Products = category.Products,
                HasProducts = category.Products.Any(i => !i.IsDeleted)
            };
        } 
    }
}