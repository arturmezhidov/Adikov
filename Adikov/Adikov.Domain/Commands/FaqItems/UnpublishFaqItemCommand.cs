using System.Data.Entity;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.FaqItems
{
    public class UnpublishFaqItemCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class UnpublishFaqItemCommandHandler : CommandHandler<UnpublishFaqItemCommand>
    {
        protected override void OnHandling(UnpublishFaqItemCommand command, CommandResult result)
        {
            FaqItem item = DataContext.FaqItems.Find(command.Id);

            if (item == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            item.IsPublished = false;

            DataContext.Entry(item).State = EntityState.Modified;
        }
    }
}