using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Columns
{
    public class SortUpColumnCommand : CommandBase
    {
        public int TableId { get; set; }

        public int TableColumnId { get; set; }
    }

    public class SortUpColumnCommandHandler : CommandHandler<SortUpColumnCommand>
    {
        protected override void OnHandling(SortUpColumnCommand command, CommandResult result)
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

            if (columns.First().Id == command.TableColumnId)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            for (int i = 1; i < columns.Count; i++)
            {
                TableColumn column = columns[i];
                column.SortNumber = i;

                if (column.Id == command.TableColumnId)
                {
                    TableColumn prevColumn = columns[i - 1];
                    column.SortNumber = prevColumn.SortNumber;
                    prevColumn.SortNumber = i;
                }

                DataContext.Entry(column).State = EntityState.Modified;
            }
        }
    }
}