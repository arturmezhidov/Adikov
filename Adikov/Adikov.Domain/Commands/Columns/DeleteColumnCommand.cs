using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Columns
{
    public class DeleteColumnCommand : CommandBase
    {
        public int Id { get; }

        public DeleteColumnCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteColumnCommandHandler : CommandHandler<DeleteColumnCommand>
    {
        protected override void OnHandling(DeleteColumnCommand command, CommandResult result)
        {
            var item = DataContext.Columns.Find(command.Id);

            if (item == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            item.IsDeleted = true;
            DataContext.Entry(item).State = EntityState.Modified;
        }
    }
}