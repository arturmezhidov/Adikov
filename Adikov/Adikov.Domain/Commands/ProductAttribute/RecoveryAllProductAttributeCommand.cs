using System.Data.Entity;
using System.Linq;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.ProductAttribute
{
    public class RecoveryAllProductAttributeCommand : CommandBase
    {
    }

    public class RecoveryAllProductAttributeCommandHandler : CommandHandler<RecoveryAllProductAttributeCommand>
    {
        protected override void OnHandling(RecoveryAllProductAttributeCommand command, CommandResult result)
        {
            var recoveringItems = DataContext.ProductAttributes.Where(i => i.IsDeleted);

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