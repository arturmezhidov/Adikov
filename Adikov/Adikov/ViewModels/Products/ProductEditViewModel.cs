using System.Collections.Generic;
using System.Web.Mvc;

namespace Adikov.ViewModels.Products
{
    public class ProductEditViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int TableId { get; set; }

        // Read only properties
        public List<SelectListItem> CategorySelectListItems { get; set; }

        public List<SelectListItem> TableSelectListItems { get; set; }
    }
}