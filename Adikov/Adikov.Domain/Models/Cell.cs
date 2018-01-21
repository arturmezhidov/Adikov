namespace Adikov.Domain.Models
{
    public class Cell : BaseEntity
    {
        public string Value { get; set; }

        public int RowId { get; set; }

        public virtual Row Row { get; set; }

        public int ColumnId { get; set; }

        public virtual Column Column { get; set; }
    }
}