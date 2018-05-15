using System.Data.Entity;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.FaqItems
{
    public class DeleteFaqItemCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class DeleteFaqItemCommandHandler : CommandHandler<DeleteFaqItemCommand>
    {
        protected override void OnHandling(DeleteFaqItemCommand command, CommandResult result)
        {
            FaqItem item = DataContext.FaqItems.Find(command.Id);

            if (item == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            item.IsDeleted = true;

            DataContext.Entry(item).State = EntityState.Modified;
        }
    }
}