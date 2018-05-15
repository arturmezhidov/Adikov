namespace Adikov.Domain.Models
{
    public class FaqItem : BaseEntity
    {
        public string Title { get; set; }

        public string ShortContent { get; set; }

        public string HtmlContent { get; set; }

        public bool IsDysplayOnMainScreen { get; set; }

        public bool IsPublished { get; set; }

        public bool IsHtmlContentDisplay { get; set; }

        public int FaqCategoryId { get; set; }

        public virtual FaqCategory FaqCategory { get; set; }
    }
}