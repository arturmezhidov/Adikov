using System.Collections.Generic;

namespace Adikov.ViewModels.ProductCategory
{
    public class ProductCategoryIndexViewModel
    {
        public IEnumerable<ProductCategoryViewModel> ActiveCategories { get; set; }

        public IEnumerable<ProductCategoryViewModel> DeletedCategories { get; set; }

        public ProductCategoryAddViewModel NewProductCategory { get; set; }

        public ProductCategoryEditViewModel EditProductCategory { get; set; }
    }
}