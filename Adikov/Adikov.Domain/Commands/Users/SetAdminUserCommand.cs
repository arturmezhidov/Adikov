using System.Data.Entity;
using System.Linq;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Users
{
    public class SetAdminUserCommand : CommandBase
    {
        public string Id { get; set; }
    }

    public class SetAdminUserCommandHandler : CommandHandler<SetAdminUserCommand>
    {
        protected override void OnHandling(SetAdminUserCommand command, CommandResult result)
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

            if (!user.Roles.Any(i => i.RoleId == role.Id))
            {
                user.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole
                {
                    UserId = user.Id,
                    RoleId = role.Id
                });
            }

            DataContext.Entry(user).State = EntityState.Modified;
        }
    }
}