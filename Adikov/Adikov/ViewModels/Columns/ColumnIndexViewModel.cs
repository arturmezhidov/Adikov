using System.Collections.Generic;

namespace Adikov.ViewModels.Columns
{
    public class ColumnIndexViewModel
    {
        public IEnumerable<ColumnViewModel> ActiveColumns { get; set; }

        public IEnumerable<ColumnViewModel> DeletedColumns { get; set; }

        public ColumnViewModel NewColumn { get; set; }

        public ColumnViewModel EditColumn { get; set; }
    }
}