using System.Linq;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.ProductCategory
{
    public class ClearProductCategoryCommand : CommandBase
    {
    }

    public class ClearProductCategoryCommandHandler : CommandHandler<ClearProductCategoryCommand>
    {
        protected override void OnHandling(ClearProductCategoryCommand command, CommandResult result)
        {
            var deletingItems = DataContext.ProductCategories.Where(i => i.IsDeleted).ToList();

            if (!deletingItems.Any())
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            foreach (var item in deletingItems)
            {
                DataContext.ProductCategories.Remove(item);
            }
        }
    }
}