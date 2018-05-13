using System;

namespace Adikov.Domain.Models
{
    public class Message : BaseEntity
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Content { get; set; }

        public bool IsSent { get; set; }

        public string NotSentReason { get; set; } 

        public string SentEmails { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsRead { get; set; }
    }
}