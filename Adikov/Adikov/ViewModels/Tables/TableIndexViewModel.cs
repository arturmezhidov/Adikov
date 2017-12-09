using System.Collections.Generic;

namespace Adikov.ViewModels.Tables
{
    public class TableIndexViewModel
    {
        public IEnumerable<TableViewModel> ActiveTables { get; set; }

        public IEnumerable<TableViewModel> DeletedTables { get; set; }
    }
}