using Adikov.Domain.Commands.Settings;
using Adikov.Infrastructura.Commands;
using Adikov.Platform.Settings;

namespace Adikov.Domain.Commands.About
{
    public class EditAboutHeaderCommand : CommandBase
    {
        public AboutHeader Header { get; set; }
    }

    public class EditAboutHeaderCommandHandler : BaseSettingsCommandHandler<EditAboutHeaderCommand>
    {
        protected override void OnHandling(EditAboutHeaderCommand command, CommandResult result)
        {
            UpdateSettings(command.Header);
        }
    }
}