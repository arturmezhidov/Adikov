using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Adikov.ViewModels.ProductCategory
{
    public class ProductCategoryEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public string Icon { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }
}