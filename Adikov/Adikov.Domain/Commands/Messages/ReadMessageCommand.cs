using System.Data.Entity;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Messages
{
    public class ReadMessageCommand : CommandBase
    {
        public int Id { get; set; }

        public static CommandResult Execute(int id)
        {
            return new ReadMessageCommandHandler().Handle(new ReadMessageCommand
            {
                Id = id
            });
        }
    }

    public class ReadMessageCommandHandler : CommandHandler<ReadMessageCommand>
    {
        protected override void OnHandling(ReadMessageCommand command, CommandResult result)
        {
            Message message = DataContext.Messages.Find(command.Id);

            if (message == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            message.IsRead = true;

            DataContext.Entry(message).State = EntityState.Modified;
        }
    }
}