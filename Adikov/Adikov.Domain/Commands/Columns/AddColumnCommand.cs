using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Columns
{
    public class AddColumnCommand : CommandBase
    {
        public string Name { get; set; }

        public ColumnType Type { get; set; }
    }

    public class AddColumnCommandHandler : CommandHandler<AddColumnCommand>
    {
        protected override void OnHandling(AddColumnCommand command, CommandResult result)
        {
            var newItem = new Column
            {
                Name = command.Name,
                Type = command.Type
            };

            DataContext.Columns.Add(newItem);
        }
    }
}