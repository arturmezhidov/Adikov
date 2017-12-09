using System.Collections.Generic;
using System.Web.Mvc;

namespace Adikov.ViewModels.Tables
{
    public class TableEditViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<int> Columns { get; set; }

        // Read only properties
        public List<SelectListItem> SelectListItems { get; set; }
    }
}