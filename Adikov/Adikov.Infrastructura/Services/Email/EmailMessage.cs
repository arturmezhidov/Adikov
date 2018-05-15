using System.Collections.Generic;

namespace Adikov.Infrastructura.Services.Email
{
    public class EmailMessage
    {
        public string Username { get; set; }

        public string From { get; set; }

        public string Password { get; set; }

        public string To { get; set; }

        public List<string> CC { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }
    }
}