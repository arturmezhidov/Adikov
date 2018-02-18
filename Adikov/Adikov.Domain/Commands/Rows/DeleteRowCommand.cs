using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Rows
{
    public class DeleteRowCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class DeleteRowCommandHandler : CommandHandler<DeleteRowCommand>
    {
        protected override void OnHandling(DeleteRowCommand command, CommandResult result)
        {
            var row = DataContext.Rows.Find(command.Id);

            if (row == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            if (row.Cells != null)
            {
                var cells = row.Cells.ToList();

                foreach (Cell cell in cells)
                {
                    DataContext.Cells.Remove(cell);
                }
            }

            DataContext.Rows.Remove(row);
        }
    }
}