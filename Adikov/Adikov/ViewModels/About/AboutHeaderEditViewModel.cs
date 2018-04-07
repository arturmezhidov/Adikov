using System.Web;

namespace Adikov.ViewModels.About
{
    public class AboutHeaderEditViewModel
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string LinkText { get; set; }

        public string LinkUrl { get; set; }

        public string BackgroundImageUrl { get; set; }

        public HttpPostedFileBase BackgroundImage { get; set; }
    }
}