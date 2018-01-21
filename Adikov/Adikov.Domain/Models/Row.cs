using System.Collections.Generic;

namespace Adikov.Domain.Models
{
    public class Row : BaseEntity
    {
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public virtual ICollection<Cell> Cells { get; set; }
    }
}