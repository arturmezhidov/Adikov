namespace Adikov.Domain.Models
{
    public class FaqItem : BaseEntity
    {
        public string Title { get; set; }

        public string HtmlContent { get; set; }

        public int FaqCategoryId { get; set; }

        public virtual FaqCategory FaqCategory { get; set; }
    }
}