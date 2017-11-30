using System.Collections.Generic;

namespace Adikov.ViewModels.ProductCategory
{
    public class ProductCategoryIndexViewModel
    {
        public IEnumerable<ProductCategoryViewModel> ActiveCategories { get; set; }

        public IEnumerable<ProductCategoryViewModel> DeletedCategories { get; set; }

        public ProductCategoryViewModel NewProductCategory { get; set; }

        public ProductCategoryViewModel EditProductCategory { get; set; }
    }
}