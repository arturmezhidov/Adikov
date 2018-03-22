using System.Collections.Generic;

namespace Adikov.Domain.Models
{
    public class FaqCategory : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<FaqItem> FaqItems { get; set; }
    }
}