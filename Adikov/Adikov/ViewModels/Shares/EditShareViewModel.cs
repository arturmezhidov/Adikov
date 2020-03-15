using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Adikov.ViewModels.Shares
{
    public class EditShareViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public DateTime? EndDate { get; set; }

        public string RibbonText { get; set; }

        public string RibbonColor { get; set; }

        public bool IsRibbonDisplayed { get; set; }

        public string ImageUrl { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }
}