using Adikov.Domain.Commands.Settings;
using Adikov.Infrastructura.Commands;
using Adikov.Platform.Settings;

namespace Adikov.Domain.Commands.About
{
    public class EditAboutLinksCommand : CommandBase
    {
        public AboutLinks Links { get; set; }

        public Models.File File { get; set; }
    }

    public class EditAboutLinksCommandHandler : BaseSettingsCommandHandler<EditAboutLinksCommand>
    {
        protected override void OnHandling(EditAboutLinksCommand command, CommandResult result)
        {
            if (command.File != null)
            {
                command.Links.ImageId = command.File.Id.ToString();
            }

            UpdateSettings(command.Links);
        }
    }
}