using System.Data.Entity;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Messages
{
    public class DeleteMessageCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class DeleteMessageCommandHandler : CommandHandler<DeleteMessageCommand>
    {
        protected override void OnHandling(DeleteMessageCommand command, CommandResult result)
        {
            Message message = DataContext.Messages.Find(command.Id);

            if (message == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            message.IsDeleted = true;

            DataContext.Entry(message).State = EntityState.Modified;
        }
    }
}