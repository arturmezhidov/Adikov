using System.Data.Entity;
using System.Linq;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Categories
{
    public class RecoveryAllCategoryCommand : CommandBase
    {
    }

    public class RecoveryAllCategoryCommandHandler : CommandHandler<RecoveryAllCategoryCommand>
    {
        protected override void OnHandling(RecoveryAllCategoryCommand command, CommandResult result)
        {
            var recoveringItems = DataContext.Categories.Where(i => i.IsDeleted);

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