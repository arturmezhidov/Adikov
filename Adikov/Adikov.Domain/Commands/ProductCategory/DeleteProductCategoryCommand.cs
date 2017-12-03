using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.ProductCategory
{
    public class DeleteProductCategoryCommand : CommandBase
    {
        public int Id { get; }

        public DeleteProductCategoryCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteProductCategoryCommandHandler : CommandHandler<DeleteProductCategoryCommand>
    {
        protected override void OnHandling(DeleteProductCategoryCommand command, CommandResult result)
        {
            var item = DataContext.ProductCategories.Find(command.Id);

            if (item == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            item.IsDeleted = true;
            DataContext.Entry(item).State = EntityState.Modified;
        }
    }
}