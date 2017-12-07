using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Columns
{
    public class RecoveryColumnCommand : CommandBase
    {
        public int Id { get; }

        public RecoveryColumnCommand(int id)
        {
            Id = id;
        }
    }

    public class RecoveryColumnCommandHandler : CommandHandler<RecoveryColumnCommand>
    {
        protected override void OnHandling(RecoveryColumnCommand command, CommandResult result)
        {
            var item = DataContext.Columns.Find(command.Id);

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