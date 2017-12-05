using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Adikov.ViewModels.Product
{
    public class ProductAddViewModel
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public List<int> Attributes { get; set; }

        public IEnumerable<SelectListItem> AttributesListItems { get; set; }
    }
}