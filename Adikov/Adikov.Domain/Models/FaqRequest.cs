using System;

namespace Adikov.Domain.Models
{
    public class FaqRequest : BaseEntity
    {
        public string UserId { get; set; }

        public string Question { get; set; }

        public FaqRequestStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}