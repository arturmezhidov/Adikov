using System.Collections.Generic;
using Adikov.Infrastructura.Interfaces;

namespace Adikov.Domain.Models
{
    public class ProductCategory : BaseEntity, ISortable
    {
        public string Icon { get; set; }

        public string Name { get; set; }

        public ProductCategoryType Type { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public int SortNumber { get; set; }
    }
}