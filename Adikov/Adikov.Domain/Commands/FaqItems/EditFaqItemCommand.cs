using System.Data.Entity;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.FaqItems
{
    public class EditFaqItemCommand : CommandBase
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortContent { get; set; }

        public string HtmlContent { get; set; }

        public int FaqCategoryId { get; set; }

        public bool IsDysplayOnMainScreen { get; set; }

        public bool IsPublished { get; set; }

        public bool IsHtmlContentDisplay { get; set; }
    }

    public class EditFaqItemCommandHandler : CommandHandler<EditFaqItemCommand>
    {
        protected override void OnHandling(EditFaqItemCommand command, CommandResult result)
        {
            FaqItem item = DataContext.FaqItems.Find(command.Id);

            if (item == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            item.Title = command.Title;
            item.ShortContent = command.ShortContent;
            item.HtmlContent = command.HtmlContent;
            item.FaqCategoryId = command.FaqCategoryId;
            item.IsPublished = command.IsPublished;
            item.IsHtmlContentDisplay = command.IsHtmlContentDisplay;
            item.IsDysplayOnMainScreen = command.IsDysplayOnMainScreen;

            DataContext.Entry(item).State = EntityState.Modified;
        }
    }
}