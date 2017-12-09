using System.Linq;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Tables
{
    public class ClearTableCommand : CommandBase
    {
    }

    public class ClearTableCommandHandler : CommandHandler<ClearTableCommand>
    {
        protected override void OnHandling(ClearTableCommand command, CommandResult result)
        {
            var deletingItems = DataContext.Tables.Where(i => i.IsDeleted).ToList();

            if (!deletingItems.Any())
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            foreach (var item in deletingItems)
            {
                DataContext.Tables.Remove(item);
            }
        }
    }
}