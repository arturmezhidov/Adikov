namespace Adikov.Domain.Models
{
    public class ProductAttributeMatrix : BaseEntity
    {
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int ProductAttributeId { get; set; }

        public virtual ProductAttribute ProductAttribute { get; set; }
    }
}