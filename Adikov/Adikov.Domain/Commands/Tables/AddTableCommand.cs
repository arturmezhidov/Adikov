using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Tables
{
    public class AddTableCommand : CommandBase
    {
        public string Name { get; set; }

        public List<int> Columns { get; set; }
    }

    public class AddTableCommandHandler : CommandHandler<AddTableCommand>
    {
        protected override void OnHandling(AddTableCommand command, CommandResult result)
        {
            if (command.Columns == null || !command.Columns.Any())
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            var newItem = new Table
            {
                Name = command.Name
            };

            int order = 0;

            newItem.TableColumns = command.Columns.Distinct().Select(i => new TableColumn
            {
                ColumnId = i,
                Table = newItem,
                SortNumber = order++
            }).ToList();

            DataContext.Tables.Add(newItem);
        }
    }
}