using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Adikov.ViewModels.Blog
{
    public class AddBlogViewModel
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public string PreviewContent { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public string HtmlContent { get; set; }

        public bool IsPublished { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }
}