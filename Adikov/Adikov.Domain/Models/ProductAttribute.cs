namespace Adikov.Domain.Models
{
    public class ProductAttribute : BaseEntity
    {
        public string Name { get; set; }

        public ProductAttributeType Type { get; set; }
    }
}