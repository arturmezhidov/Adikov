using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Rows
{
    public class EditCell
    {
        public int CellId { get; set; }

        public int ColumnId { get; set; }

        public string Value { get; set; }
    }

    public class EditRowCommand : CommandBase
    {
        public int RowId { get; set; }

        public List<EditCell> Cells { get; set; }
    }

    public class EditProductCommandHandler : CommandHandler<EditRowCommand, CommandResult>
    {
        protected override void OnHandling(EditRowCommand command, CommandResult result)
        {
            Row row = DataContext.Rows.Find(command.RowId);

            if (row == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            if (row.Cells == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            List<Cell> newCells = new List<Cell>();

            foreach (var cell in command.Cells)
            {
                Cell rowCell = row.Cells.FirstOrDefault(c => c.Id == cell.CellId);

                if (rowCell != null)
                {
                    rowCell.Value = cell.Value;
                    DataContext.Entry(rowCell).State = EntityState.Modified;
                }
                else
                {
                    newCells.Add(new Cell
                    {
                        RowId = command.RowId,
                        ColumnId = cell.ColumnId,
                        Value = cell.Value
                    });
                }
            }

            if (newCells.Any())
            {
                DataContext.SaveChanges();

                newCells.ForEach(c => { DataContext.Cells.Add(c); });
            }
        }
    }
}