using Adikov.Domain.Models;

namespace Adikov.ViewModels.Columns
{
    public class ColumnViewModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public ColumnType Type { get; set; }

        public bool IsDeleted { get; set; }
    }
}