using Adikov.Domain.Commands.Settings;
using Adikov.Infrastructura.Commands;
using Adikov.Platform.Settings;

namespace Adikov.Domain.Commands.About
{
    public class EditAboutCompanyCommand : CommandBase
    {
        public AboutCompany About { get; set; }
    }

    public class EditAboutCompanyCommandHandler : BaseSettingsCommandHandler<EditAboutCompanyCommand>
    {
        protected override void OnHandling(EditAboutCompanyCommand command, CommandResult result)
        {
            UpdateSettings(command.About);
        }
    }
}