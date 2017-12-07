using System.Collections.Generic;

namespace Adikov.Domain.Models
{
    public class Table : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Column> Columns { get; set; }
    }
}