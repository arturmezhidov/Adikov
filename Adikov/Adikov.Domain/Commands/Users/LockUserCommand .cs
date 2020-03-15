using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Users
{
    public class LockUserCommand : CommandBase
    {
        public string Id { get; set; }
    }

    public class LockUserCommandHandler : CommandHandler<LockUserCommand>
    {
        protected override void OnHandling(LockUserCommand command, CommandResult result)
        {
            var user = DataContext.Users.Find(command.Id);

            if (user == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            user.IsLock = true;

            DataContext.Entry(user).State = EntityState.Modified;
        }
    }
}