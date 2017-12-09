using System.Data.Entity;
using System.Linq;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Tables
{
    public class RecoveryAllTableCommand : CommandBase
    {
    }

    public class RecoveryAllTableCommandHandler : CommandHandler<RecoveryAllTableCommand>
    {
        protected override void OnHandling(RecoveryAllTableCommand command, CommandResult result)
        {
            var recoveringItems = DataContext.Tables.Where(i => i.IsDeleted);

            if (!recoveringItems.Any())
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            foreach (var item in recoveringItems)
            {
                item.IsDeleted = false;
                DataContext.Entry(item).State = EntityState.Modified;
            }
        }
    }
}