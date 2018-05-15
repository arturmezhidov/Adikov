using Adikov.Platform.Configuration;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace Adikov.Infrastructura.Services.Email
{
    public class EmailService : IEmailService
    {
        public string Send(EmailMessage message)
        {
            try
            {
                MailAddress to = new MailAddress(message.To);
                MailAddress from = new MailAddress(message.From, message.Username);

                MailMessage m = new MailMessage(from, to)
                {
                    Subject = message.Subject,
                    Body = message.Content,
                    IsBodyHtml = true
                };

                if(message.CC != null && message.CC.Any())
                {
                    message.CC.ForEach(i => m.CC.Add(i));
                }

                SmtpClient smtp = new SmtpClient(PlatformConfiguration.SmtpServerName, PlatformConfiguration.SmtpServerPort);

                smtp.Credentials = new NetworkCredential(message.From, message.Password);
                smtp.EnableSsl = true;
                smtp.Send(m);
            }
            catch(Exception e)
            {
                return e.ToString();
            }

            return null;
        }
    }
}