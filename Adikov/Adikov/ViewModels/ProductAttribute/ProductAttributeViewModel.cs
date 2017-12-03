using Adikov.Domain.Models;

namespace Adikov.ViewModels.ProductAttribute
{
    public class ProductAttributeViewModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public ProductAttributeType Type { get; set; }

        public bool IsDeleted { get; set; }
    }
}