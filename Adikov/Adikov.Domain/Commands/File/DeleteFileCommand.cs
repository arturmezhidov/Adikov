using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.File
{
    public class DeleteFileCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class DeleteFileCommandHandler : CommandHandler<DeleteFileCommand>
    {
        protected override void OnHandling(DeleteFileCommand command, CommandResult result)
        {
            var item = DataContext.Files.Find(command.Id);

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