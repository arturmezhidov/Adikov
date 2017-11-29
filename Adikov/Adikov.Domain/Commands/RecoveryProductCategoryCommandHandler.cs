using System.Data.Entity;

namespace Adikov.Domain.Commands
{
    public class RecoveryProductCategoryCommand : ICommand
    {
        public int Id { get; }

        public RecoveryProductCategoryCommand(int id)
        {
            Id = id;
        }
    }

    public class RecoveryProductCategoryCommandHandler : CommandHandler<RecoveryProductCategoryCommand>
    {
        protected override void OnHandling(RecoveryProductCategoryCommand command)
        {
            var item = DataContext.ProductCategories.Find(command.Id);

            if (item != null)
            {
                item.IsDeleted = false;
                DataContext.Entry(item).State = EntityState.Modified;
            }
        }
    }
}