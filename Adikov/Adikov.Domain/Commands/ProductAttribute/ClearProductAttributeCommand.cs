using System.Linq;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.ProductAttribute
{
    public class ClearProductAttributeCommand : CommandBase
    {
    }

    public class ClearProductAttributeCommandHandler : CommandHandler<ClearProductAttributeCommand>
    {
        protected override void OnHandling(ClearProductAttributeCommand command, CommandResult result)
        {
            var deletingItems = DataContext.ProductAttributes.Where(i => i.IsDeleted).ToList();

            if (!deletingItems.Any())
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            foreach (var item in deletingItems)
            {
                DataContext.ProductAttributes.Remove(item);
            }
        }
    }
}