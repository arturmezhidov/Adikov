using System.Collections.Generic;

namespace Adikov.Domain.Models
{
    public class Table : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<TableColumn> TableColumns { get; set; }
    }
}