using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Tables
{
    public class RecoveryTableCommand : CommandBase
    {
        public int Id { get; }

        public RecoveryTableCommand(int id)
        {
            Id = id;
        }
    }

    public class RecoveryTableCommandHandler : CommandHandler<RecoveryTableCommand>
    {
        protected override void OnHandling(RecoveryTableCommand command, CommandResult result)
        {
            var item = DataContext.Tables.Find(command.Id);

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