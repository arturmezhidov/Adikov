using System.Collections.Generic;
using Adikov.ViewModels.Columns;

namespace Adikov.ViewModels.Tables
{
    public class TableDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ColumnViewModel> Columns { get; set; }

        public bool? IsPreview { get; set; }
    }
}