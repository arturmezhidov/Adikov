using System.Collections.Generic;

namespace Adikov.ViewModels.Categories
{
    public class CategoryIndexViewModel
    {
        public IEnumerable<CategoryViewModel> ActiveCategories { get; set; }

        public IEnumerable<CategoryViewModel> DeletedCategories { get; set; }
    }
}