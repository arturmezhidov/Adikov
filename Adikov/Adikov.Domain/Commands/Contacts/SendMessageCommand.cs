using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Adikov.Domain.Queries.Contacts;
using Adikov.Infrastructura.Commands;
using Adikov.Infrastructura.Services.Email;
using Adikov.Platform.Configuration;
using Adikov.Platform.Settings;

namespace Adikov.Domain.Commands.Contacts
{
    public class SendMessageCommand : CommandBase
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Content { get; set; }
    }

    public class SendMessageCommandHandler : CommandHandler<SendMessageCommand>
    {
        public IEmailService EmailService { get; set; } = new EmailService();

        protected override void OnHandling(SendMessageCommand command, CommandResult result)
        {
            var model = new Models.KeepInTouch
            {
                Username = command.Username,
                Email = command.Email,
                Phone = command.Phone,
                Content = command.Content,
                CreatedAt = DateTime.Now
            };

            try
            {
                ContactsKeepInTouch contacts = GetKeepInTouchQuery.Execute();

                if (contacts.IsSendToEmails)
                {
                    List<string> emails = new List<string>
                    {
                        contacts.Email1,
                        contacts.Email2,
                        contacts.Email3,
                        contacts.Email4
                    }
                    .Where(i => !String.IsNullOrEmpty(i))
                    .ToList();

                    if (emails.Any())
                    {
                        EmailMessage message = new EmailMessage
                        {
                            Username = command.Username,
                            From = PlatformConfiguration.SmtpEmailAddress,
                            Password = PlatformConfiguration.SmtpEmailPassword,
                            To = emails.First(),
                            CC = emails.Skip(1).ToList(),
                            Subject = "Письмо со страницы КОНТАКТЫ!",
                            Content = FormatContent(command)
                        };

                        model.SentEmails = string.Join(", ", emails);
                        model.NotSentReason = EmailService.Send(message);
                    }
                    else
                    {
                        model.NotSentReason = "Не введена ни одна почта. Для ввода почты зайдите на сайт как администратор и перейдите в настройки формы в контактах.";
                    }
                }
                else
                {
                    model.NotSentReason = "Отправка сообщений на почту отключена. Для включения зайдите на сайт как администратор и перейдите в настройки формы в контактах.";
                }
            }
            catch(Exception e)
            {
                model.NotSentReason = e.ToString();
            }

            model.IsSent = model.NotSentReason == null;


            DataContext.KeepInTouchs.Add(model);
        }

        protected string FormatContent(SendMessageCommand command)
        {
            StringBuilder buffer = new StringBuilder();

            buffer.Append(FormatContentProperty("Пользователь", command.Username));
            buffer.Append(FormatContentProperty("Почта", command.Email));
            buffer.Append(FormatContentProperty("Телефон", command.Phone));
            buffer.Append(FormatContentProperty("Сообщение", command.Content));

            return buffer.ToString();
        }

        protected string FormatContentProperty(string label, object value)
        {
            return $"{label}: <strong>{value}</strong><br/>";
        }
    }
}