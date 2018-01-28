using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Columns
{
    public class SortDownColumnCommand : CommandBase
    {
        public int TableId { get; set; }

        public int TableColumnId { get; set; }
    }

    public class SortDownColumnCommandHandler : CommandHandler<SortDownColumnCommand>
    {
        protected override void OnHandling(SortDownColumnCommand command, CommandResult result)
        {
            List<TableColumn> columns = DataContext.TableColumns
                .Where(i => i.TableId == command.TableId)
                .OrderBy(i => i.SortNumber)
                .ToList();

            if (!columns.Any())
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            if (columns.Last().Id == command.TableColumnId)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            for (int i = columns.Count - 2; i >= 0; i--)
            {
                TableColumn column = columns[i];
                column.SortNumber = i;

                if (column.Id == command.TableColumnId)
                {
                    TableColumn nextColumn = columns[i + 1];
                    column.SortNumber = nextColumn.SortNumber;
                    nextColumn.SortNumber = i;
                }

                DataContext.Entry(column).State = EntityState.Modified;
            }
        }
    }
}