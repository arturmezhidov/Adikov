using System.Data.Entity;
using System.Linq;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.ProductCategory
{
    public class RecoveryAllProductCategoryCommand : CommandBase
    {
    }

    public class RecoveryAllProductCategoryCommandHandler : CommandHandler<RecoveryAllProductCategoryCommand>
    {
        protected override void OnHandling(RecoveryAllProductCategoryCommand command, CommandResult result)
        {
            var recoveringItems = DataContext.ProductCategories.Where(i => i.IsDeleted);

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