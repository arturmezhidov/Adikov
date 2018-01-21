using System.Collections.Generic;

namespace Adikov.Domain.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int TableId { get; set; }

        public virtual Table Table { get; set; }

        public virtual ICollection<Row> Rows { get; set; }
    }
}