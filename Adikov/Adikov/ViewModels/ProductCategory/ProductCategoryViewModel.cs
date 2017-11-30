using System.ComponentModel.DataAnnotations;
using Adikov.Domain.Models;

namespace Adikov.ViewModels.ProductCategory
{
    public class ProductCategoryViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public string Icon { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public string Name { get; set; }

        public ProductCategoryType Type { get; set; }

        public bool IsDeleted { get; set; }
    }
}