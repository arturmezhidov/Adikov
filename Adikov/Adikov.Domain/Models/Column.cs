using System.Collections.Generic;

namespace Adikov.Domain.Models
{
    public class Column : BaseEntity
    {
        public string Name { get; set; }

        public ColumnType Type { get; set; }

        public virtual ICollection<Table> Tables { get; set; }
    }
}