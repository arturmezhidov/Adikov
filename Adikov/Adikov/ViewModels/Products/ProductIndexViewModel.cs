using System.Collections.Generic;

namespace Adikov.ViewModels.Products
{
    public class ProductIndexViewModel
    {
        public IEnumerable<ProductViewModel> ActiveProducts { get; set; }

        public IEnumerable<ProductViewModel> DeletedProducts { get; set; }

        public ProductAddViewModel NewProduct { get; set; }

        public ProductEditViewModel EditProduct { get; set; }
    }
}