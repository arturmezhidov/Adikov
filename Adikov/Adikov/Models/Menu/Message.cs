using System;

namespace Adikov.Models.Menu
{
    public class Message
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ImageUrl { get; set; }
    }
}