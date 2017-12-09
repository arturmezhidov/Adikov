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

            command.Columns = command.Columns.Distinct().ToList();

            var columns = DataContext.Columns.Where(i => command.Columns.Contains(i.Id));

            var newItem = new Table
            {
                Name = command.Name,
                Columns = columns.ToList()
            };

            DataContext.Tables.Add(newItem);
        }
    }
}