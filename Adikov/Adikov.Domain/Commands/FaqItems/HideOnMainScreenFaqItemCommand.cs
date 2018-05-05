using System.Data.Entity;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.FaqItems
{
    public class HideOnMainScreenFaqItemCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class HideOnMainScreenFaqItemCommandHandler : CommandHandler<HideOnMainScreenFaqItemCommand>
    {
        protected override void OnHandling(HideOnMainScreenFaqItemCommand command, CommandResult result)
        {
            FaqItem item = DataContext.FaqItems.Find(command.Id);

            if (item == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            item.IsDysplayOnMainScreen = false;

            DataContext.Entry(item).State = EntityState.Modified;
        }
    }
}