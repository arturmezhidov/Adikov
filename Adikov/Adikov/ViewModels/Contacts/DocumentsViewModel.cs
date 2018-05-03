using System.Web;

namespace Adikov.ViewModels.Contacts
{
    public class DocumentsViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string FileUrl { get; set; }

        public string FileName { get; set; }

        public HttpPostedFileBase File { get; set; }

        public string UpdatedAt { get; set; }
    }
}