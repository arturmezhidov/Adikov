using System.Linq;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Columns
{
    public class ClearColumnCommand : CommandBase
    {
    }

    public class ClearColumnCommandHandler : CommandHandler<ClearColumnCommand>
    {
        protected override void OnHandling(ClearColumnCommand command, CommandResult result)
        {
            var deletingItems = DataContext.Columns.Where(i => i.IsDeleted).ToList();

            if (!deletingItems.Any())
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            foreach (var item in deletingItems)
            {
                DataContext.Columns.Remove(item);
            }
        }
    }
}