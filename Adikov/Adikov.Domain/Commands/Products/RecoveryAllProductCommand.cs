using System.Data.Entity;
using System.Linq;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Products
{
    public class RecoveryAllProductCommand : CommandBase
    {
    }

    public class RecoveryAllProductCommandHandler : CommandHandler<RecoveryAllProductCommand>
    {
        protected override void OnHandling(RecoveryAllProductCommand command, CommandResult result)
        {
            var recoveringItems = DataContext.Products.Where(i => i.IsDeleted);

            if (!recoveringItems.Any())
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            foreach (var item in recoveringItems)
            {
                item.IsDeleted = false;
                DataContext.Entry(item).State = EntityState.Modified;
            }
        }
    }
}