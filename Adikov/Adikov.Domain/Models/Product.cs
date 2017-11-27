namespace Adikov.Domain.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public int ProductCategoryId { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}