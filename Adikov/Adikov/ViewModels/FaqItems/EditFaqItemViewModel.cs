using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Adikov.ViewModels.FaqItems
{
    public class EditFaqItemViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string ShortContent { get; set; }

        public string HtmlContent { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public int? FaqCategoryId { get; set; }

        public bool IsDysplayOnMainScreen { get; set; }

        public bool IsPublished { get; set; }

        public bool IsHtmlContentDisplay { get; set; }

        // Read only properties
        public List<SelectListItem> CategorySelectListItems { get; set; }
    }
}