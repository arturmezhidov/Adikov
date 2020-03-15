using System.Data.Entity;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.FaqItems
{
    public class DisplayOnMainScreenFaqItemCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class DisplayOnMainScreenFaqItemCommandHandler : CommandHandler<DisplayOnMainScreenFaqItemCommand>
    {
        protected override void OnHandling(DisplayOnMainScreenFaqItemCommand command, CommandResult result)
        {
            FaqItem item = DataContext.FaqItems.Find(command.Id);

            if (item == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            item.IsDysplayOnMainScreen = true;

            DataContext.Entry(item).State = EntityState.Modified;
        }
    }
}