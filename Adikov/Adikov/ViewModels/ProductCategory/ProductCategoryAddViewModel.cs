using System.ComponentModel.DataAnnotations;
using System.Web;
using Adikov.Domain.Models;

namespace Adikov.ViewModels.ProductCategory
{
    public class ProductCategoryAddViewModel
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public string Icon { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public string Name { get; set; }

        public ProductCategoryType Type { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }
}