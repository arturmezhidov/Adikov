using System.Data.Entity;
using System.Linq;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Users
{
    public class RemoveAdminUserCommand : CommandBase
    {
        public string Id { get; set; }
    }

    public class RemoveAdminUserCommandHandler : CommandHandler<RemoveAdminUserCommand>
    {
        protected override void OnHandling(RemoveAdminUserCommand command, CommandResult result)
        {
            var user = DataContext.Users.Find(command.Id);

            if (user == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            var role = DataContext.Roles.FirstOrDefault(i => i.Name == "admin");

            if (role == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            var userRole = user.Roles.FirstOrDefault(i => i.RoleId == role.Id);

            if (userRole == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            user.Roles.Remove(userRole);

            DataContext.Entry(user).State = EntityState.Modified;
        }
    }
}