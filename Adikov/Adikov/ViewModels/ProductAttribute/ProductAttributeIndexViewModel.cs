using System.Collections.Generic;

namespace Adikov.ViewModels.ProductAttribute
{
    public class ProductAttributeIndexViewModel
    {
        public IEnumerable<ProductAttributeViewModel> ActiveAttributes { get; set; }

        public IEnumerable<ProductAttributeViewModel> DeletedAttributes { get; set; }

        public ProductAttributeViewModel NewProductAttribute { get; set; }

        public ProductAttributeViewModel EditProductAttribute { get; set; }
    }
}