using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.ProductCategory
{
    public class RecoveryProductCategoryCommand : CommandBase
    {
        public int Id { get; }

        public RecoveryProductCategoryCommand(int id)
        {
            Id = id;
        }
    }

    public class RecoveryProductCategoryCommandHandler : CommandHandler<RecoveryProductCategoryCommand>
    {
        protected override void OnHandling(RecoveryProductCategoryCommand command, CommandResult result)
        {
            var item = DataContext.ProductCategories.Find(command.Id);

            if (item == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            item.IsDeleted = false;
            DataContext.Entry(item).State = EntityState.Modified;
        }
    }
}