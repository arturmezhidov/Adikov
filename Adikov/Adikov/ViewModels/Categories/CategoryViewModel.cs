using Adikov.Domain.Models;

namespace Adikov.ViewModels.Categories
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Icon { get; set; }

        public string Name { get; set; }

        public CategoryType Type { get; set; }

        public string ImageUrl { get; set; }

        public bool IsDeleted { get; set; }
    }
}