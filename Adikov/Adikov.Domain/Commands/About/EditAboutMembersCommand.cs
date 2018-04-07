using Adikov.Domain.Commands.Settings;
using Adikov.Infrastructura.Commands;
using Adikov.Platform.Settings;

namespace Adikov.Domain.Commands.About
{
    public class EditAboutMembersCommand : CommandBase
    {
        public AboutMembers Members { get; set; }
    }

    public class EditAboutMembersCommandHandler : BaseSettingsCommandHandler<EditAboutMembersCommand>
    {
        protected override void OnHandling(EditAboutMembersCommand command, CommandResult result)
        {
            UpdateSettings(command.Members);
        }
    }
}