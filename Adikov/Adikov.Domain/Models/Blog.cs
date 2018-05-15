using System;

namespace Adikov.Domain.Models
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }

        public string PreviewContent { get; set; }

        public string HtmlContent { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsPublished { get; set; }

        public int FileId { get; set; }

        public virtual File File { get; set; }
    }
}