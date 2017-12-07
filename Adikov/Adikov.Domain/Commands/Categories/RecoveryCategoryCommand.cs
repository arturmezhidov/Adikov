using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Categories
{
    public class RecoveryCategoryCommand : CommandBase
    {
        public int Id { get; }

        public RecoveryCategoryCommand(int id)
        {
            Id = id;
        }
    }

    public class RecoveryCategoryCommandHandler : CommandHandler<RecoveryCategoryCommand>
    {
        protected override void OnHandling(RecoveryCategoryCommand command, CommandResult result)
        {
            var item = DataContext.Categories.Find(command.Id);

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