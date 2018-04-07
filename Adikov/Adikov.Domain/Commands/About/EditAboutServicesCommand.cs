using Adikov.Domain.Commands.Settings;
using Adikov.Infrastructura.Commands;
using Adikov.Platform.Settings;

namespace Adikov.Domain.Commands.About
{
    public class EditAboutServicesCommand : CommandBase
    {
        public AboutServices Services { get; set; }
    }

    public class EditAboutServicesCommandHandler : BaseSettingsCommandHandler<EditAboutServicesCommand>
    {
        protected override void OnHandling(EditAboutServicesCommand command, CommandResult result)
        {
            UpdateSettings(command.Services);
        }
    }
}