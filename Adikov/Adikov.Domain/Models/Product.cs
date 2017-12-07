namespace Adikov.Domain.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}