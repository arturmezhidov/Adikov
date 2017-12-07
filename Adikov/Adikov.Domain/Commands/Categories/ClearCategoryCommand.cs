using System.Linq;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Categories
{
    public class ClearCategoryCommand : CommandBase
    {
    }

    public class ClearCategoryCommandHandler : CommandHandler<ClearCategoryCommand>
    {
        protected override void OnHandling(ClearCategoryCommand command, CommandResult result)
        {
            var deletingItems = DataContext.Categories.Where(i => i.IsDeleted).ToList();

            if (!deletingItems.Any())
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            foreach (var item in deletingItems)
            {
                DataContext.Categories.Remove(item);
            }
        }
    }
}