using Adikov.Domain.Commands.FaqRequests;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.FaqItems
{
    public class AddFaqItemCommand : CommandBase
    {
        public string Title { get; set; }

        public string ShortContent { get; set; }

        public string HtmlContent { get; set; }

        public int FaqCategoryId { get; set; }

        public int? RequestId { get; set; }

        public bool IsDysplayOnMainScreen { get; set; }

        public bool IsPublished { get; set; }

        public bool IsHtmlContentDisplay { get; set; }
    }

    public class AddFaqItemCommandHandler : CommandHandler<AddFaqItemCommand>
    {
        protected override void OnHandling(AddFaqItemCommand command, CommandResult result)
        {
            FaqItem item = new FaqItem
            {
                Title = command.Title,
                ShortContent = command.ShortContent,
                HtmlContent = command.HtmlContent,
                FaqCategoryId = command.FaqCategoryId,
                IsPublished = command.IsPublished,
                IsHtmlContentDisplay = command.IsHtmlContentDisplay,
                IsDysplayOnMainScreen = command.IsDysplayOnMainScreen
            };

            DataContext.FaqItems.Add(item);

            if (command.RequestId.HasValue)
            {
                new ConfirmRequestCommandHandler().Handle(new ConfirmRequestCommand
                {
                    Id = command.RequestId.Value
                });
            }
        }
    }
}