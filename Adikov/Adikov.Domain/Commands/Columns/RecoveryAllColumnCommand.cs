using System.Data.Entity;
using System.Linq;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Columns
{
    public class RecoveryAllColumnCommand : CommandBase
    {
    }

    public class RecoveryAllColumnCommandHandler : CommandHandler<RecoveryAllColumnCommand>
    {
        protected override void OnHandling(RecoveryAllColumnCommand command, CommandResult result)
        {
            var recoveringItems = DataContext.Columns.Where(i => i.IsDeleted);

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