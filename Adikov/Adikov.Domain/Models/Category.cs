using System.Collections.Generic;

namespace Adikov.Domain.Models
{
    public class Category : BaseEntity 
    {
        public string Icon { get; set; }

        public string Name { get; set; }

        public CategoryType Type { get; set; }

        public int SortNumber { get; set; }

        public int FileId { get; set; }

        public virtual File File { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}