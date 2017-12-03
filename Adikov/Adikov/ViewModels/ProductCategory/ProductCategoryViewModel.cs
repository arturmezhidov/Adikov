using Adikov.Domain.Models;

namespace Adikov.ViewModels.ProductCategory
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }

        public string Icon { get; set; }

        public string Name { get; set; }

        public ProductCategoryType Type { get; set; }

        public string ImageUrl { get; set; }

        public bool IsDeleted { get; set; }
    }
}