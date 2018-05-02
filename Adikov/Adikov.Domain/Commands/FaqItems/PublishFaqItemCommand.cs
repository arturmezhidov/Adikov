using System.Data.Entity;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.FaqItems
{
    public class PublishFaqItemCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class PublishFaqItemCommandHandler : CommandHandler<PublishFaqItemCommand>
    {
        protected override void OnHandling(PublishFaqItemCommand command, CommandResult result)
        {
            FaqItem item = DataContext.FaqItems.Find(command.Id);

            if (item == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            item.IsPublished = true;

            DataContext.Entry(item).State = EntityState.Modified;
        }
    }
}