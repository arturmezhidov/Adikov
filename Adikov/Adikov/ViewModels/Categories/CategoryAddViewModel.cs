using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Adikov.ViewModels.Categories
{
    public class CategoryAddViewModel
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public string Icon { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public string Name { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }
}