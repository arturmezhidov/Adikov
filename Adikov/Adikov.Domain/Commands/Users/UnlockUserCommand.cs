using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Users
{
    public class UnlockUserCommand : CommandBase
    {
        public string Id { get; set; }
    }

    public class UnlockUserCommandHandler : CommandHandler<UnlockUserCommand>
    {
        protected override void OnHandling(UnlockUserCommand command, CommandResult result)
        {
            var user = DataContext.Users.Find(command.Id);

            if (user == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            user.IsLock = false;

            DataContext.Entry(user).State = EntityState.Modified;
        }
    }
}