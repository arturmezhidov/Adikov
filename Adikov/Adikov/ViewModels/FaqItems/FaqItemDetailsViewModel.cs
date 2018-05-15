using Adikov.Domain.Models;

namespace Adikov.ViewModels.FaqItems
{
    public class FaqItemDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortContent { get; set; }

        public string HtmlContent { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsDysplayOnMainScreen { get; set; }

        public bool IsPublished { get; set; }

        public bool IsHtmlContentDisplay { get; set; }

        public FaqCategory FaqCategory { get; set; }
    }
}