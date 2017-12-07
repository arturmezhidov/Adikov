using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Categories
{
    public class DeleteCategoryCommand : CommandBase
    {
        public int Id { get; }

        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteCategoryCommandHandler : CommandHandler<DeleteCategoryCommand>
    {
        protected override void OnHandling(DeleteCategoryCommand command, CommandResult result)
        {
            var item = DataContext.Categories.Find(command.Id);

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