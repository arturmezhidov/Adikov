using System;
using System.Data.Entity;
using System.IO;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Profile
{
    public class UpdateAvatarCommand : CommandBase
    {
        public int FileId { get; set; }
    }

    public class UpdateAvatarCommandHandler : CommandHandler<UpdateAvatarCommand, CommandResult>
    {
        protected override void OnHandling(UpdateAvatarCommand command, CommandResult result)
        {
            ApplicationUser user = DataContext.Users.Find(UserContext.UserId);

            if (user == null)
            {
                result.ResultCode = CommandResultCode.Fail;
                return;
            }

            user.AvatarId = command.FileId;

            DataContext.Entry(user).State = EntityState.Modified;

            UserContext.Reset();
        }
    }
}