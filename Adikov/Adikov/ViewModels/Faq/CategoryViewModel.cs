using System.ComponentModel.DataAnnotations;

namespace Adikov.ViewModels.Faq
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название категории обязательно для заполнения")]
        public string Name { get; set; }
    }
}