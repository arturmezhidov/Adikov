using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adikov.Domain.Models
{
    public class TableColumn : BaseEntity
    {
        public int ColumnId { get; set; }

        public Column Column { get; set; }

        public int TableId { get; set; }

        public Table Table { get; set; }

        public int SortNumber { get; set; }
    }
}
