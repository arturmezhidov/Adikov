using Adikov.Domain.Commands.Settings;
using Adikov.Infrastructura.Commands;
using Adikov.Platform.Settings;

namespace Adikov.Domain.Commands.About
{
    public class EditAboutHeaderCommand : CommandBase
    {
        public AboutHeader Header { get; set; }

        public Models.File File { get; set; }
    }

    public class EditAboutHeaderCommandHandler : BaseSettingsCommandHandler<EditAboutHeaderCommand>
    {
        protected override void OnHandling(EditAboutHeaderCommand command, CommandResult result)
        {
            if (command.File != null)
            {
                command.Header.BackgroundImageId = command.File.Id.ToString();
            }

            UpdateSettings(command.Header);
        }
    }
}