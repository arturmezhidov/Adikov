using System.Linq;

namespace Adikov.Domain.Commands
{
    public class ClearProductCategoryCommand : ICommand
    {
    }

    public class ClearProductCategoryCommandHandler : CommandHandler<ClearProductCategoryCommand>
    {
        protected override void OnHandling(ClearProductCategoryCommand command)
        {
            var deletedItems = DataContext.ProductCategories.Where(i => i.IsDeleted);

            foreach (var item in deletedItems)
            {
                DataContext.ProductCategories.Remove(item);
            }
        }
    }
}