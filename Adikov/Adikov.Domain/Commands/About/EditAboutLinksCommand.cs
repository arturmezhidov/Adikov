using Adikov.Domain.Commands.Settings;
using Adikov.Infrastructura.Commands;
using Adikov.Platform.Settings;

namespace Adikov.Domain.Commands.About
{
    public class EditAboutLinksCommand : CommandBase
    {
        public AboutLinks Links { get; set; }
    }

    public class EditAboutLinksCommandHandler : BaseSettingsCommandHandler<EditAboutLinksCommand>
    {
        protected override void OnHandling(EditAboutLinksCommand command, CommandResult result)
        {
            UpdateSettings(command.Links);
        }
    }
}