using System;

namespace Adikov.Domain.Models
{
    public class Share : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime EndDate { get; set; }

        public string RibbonText { get; set; }

        public string RibbonColor { get; set; }

        public bool IsRibbonDisplayed { get; set; }

        public int FileId { get; set; }

        public virtual File File { get; set; }
    }
}