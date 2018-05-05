using System;

namespace Adikov.Models.Menu
{
    public class FaqRequest
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public string AvatarLink { get; set; }
    }
}