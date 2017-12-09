using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Tables
{
    public class EditTableCommand : CommandBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<int> Columns { get; set; }
    }

    public class EditTableCommandHandler : CommandHandler<EditTableCommand>
    {
        protected override void OnHandling(EditTableCommand command, CommandResult result)
        {
            if (command.Columns == null || !command.Columns.Any())
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            Table table = DataContext.Tables.Find(command.Id);

            if (table == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            List<int> newColumns = command.Columns.Distinct().ToList();
            List<int> tableComuns = table.Columns.Select(i => i.Id).ToList();

            // Deleting
            foreach (int columnId in tableComuns)
            {
                if (newColumns.Contains(columnId))
                {
                    continue;
                }

                Column column = table.Columns.FirstOrDefault(i => i.Id == columnId);

                if (column == null)
                {
                    continue;
                }

                table.Columns.Remove(column);
            }

            // Adding
            foreach (int columnId in newColumns)
            {
                if (tableComuns.Contains(columnId))
                {
                    continue;
                }

                Column column = DataContext.Columns.Find(columnId);

                if (column == null)
                {
                    continue;
                }

                table.Columns.Add(column);
            }

            DataContext.Entry(table).State = EntityState.Modified;
        }
    }
}