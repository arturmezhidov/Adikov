using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Columns
{
    public class EditColumnCommand : CommandBase
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class EditColumnCommandHandler : CommandHandler<EditColumnCommand>
    {
        protected override void OnHandling(EditColumnCommand command, CommandResult result)
        {
            var item = DataContext.Columns.Find(command.Id);

            if (item == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            item.Name = command.Name;

            DataContext.Entry(item).State = EntityState.Modified;
        }
    }
}