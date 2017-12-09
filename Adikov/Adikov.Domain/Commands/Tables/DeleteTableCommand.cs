using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Tables
{
    public class DeleteTableCommand : CommandBase
    {
        public int Id { get; }

        public DeleteTableCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteTableCommandHandler : CommandHandler<DeleteTableCommand>
    {
        protected override void OnHandling(DeleteTableCommand command, CommandResult result)
        {
            var item = DataContext.Tables.Find(command.Id);

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