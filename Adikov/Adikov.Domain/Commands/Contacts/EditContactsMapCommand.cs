using Adikov.Domain.Commands.Settings;
using Adikov.Infrastructura.Commands;
using Adikov.Platform.Settings;

namespace Adikov.Domain.Commands.Contacts
{
    public class EditContactsMapCommand : CommandBase
    {
        public ContactsMap Map { get; set; }
    }

    public class EditContactsMapCommandHandler : BaseSettingsCommandHandler<EditContactsMapCommand>
    {
        protected override void OnHandling(EditContactsMapCommand command, CommandResult result)
        {
            UpdateSettings(command.Map);
        }
    }
}