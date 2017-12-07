using System.ComponentModel.DataAnnotations;

namespace Adikov.ViewModels.Products
{
    public class ProductAddViewModel
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Name { get; set; }

        public int CategoryId { get; set; }
    }
}