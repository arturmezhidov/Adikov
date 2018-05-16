using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Adikov.ViewModels.Shares
{
    public class AddShareViewModel
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public DateTime? EndDate { get; set; }

        public string RibbonText { get; set; }

        public string RibbonColor { get; set; }

        public bool IsRibbonDisplayed { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public HttpPostedFileBase Image { get; set; }
    }
}