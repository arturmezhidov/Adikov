using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Products
{
    public class RecoveryProductCommand : CommandBase
    {
        public int Id { get; }

        public RecoveryProductCommand(int id)
        {
            Id = id;
        }
    }

    public class RecoveryProductCommandHandler : CommandHandler<RecoveryProductCommand>
    {
        protected override void OnHandling(RecoveryProductCommand command, CommandResult result)
        {
            var item = DataContext.Products.Find(command.Id);

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