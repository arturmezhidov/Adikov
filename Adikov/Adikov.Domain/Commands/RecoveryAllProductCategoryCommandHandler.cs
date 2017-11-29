using System.Data.Entity;
using System.Linq;

namespace Adikov.Domain.Commands
{
    public class RecoveryAllProductCategoryCommand : ICommand
    {
    }

    public class RecoveryAllProductCategoryCommandHandler : CommandHandler<RecoveryAllProductCategoryCommand>
    {
        protected override void OnHandling(RecoveryAllProductCategoryCommand command)
        {
            var deletedItems = DataContext.ProductCategories.Where(i => i.IsDeleted);

            foreach (var item in deletedItems)
            {
                item.IsDeleted = false;
                DataContext.Entry(item).State = EntityState.Modified;
            }
        }
    }
}