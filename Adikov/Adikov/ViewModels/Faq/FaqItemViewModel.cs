namespace Adikov.ViewModels.Faq
{
    public class FaqItemViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortContent { get; set; }

        public string HtmlContent { get; set; }

        public bool IsHtmlContentDisplay { get; set; }
    }
}