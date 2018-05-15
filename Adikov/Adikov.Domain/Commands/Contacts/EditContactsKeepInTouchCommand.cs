using Adikov.Domain.Commands.Settings;
using Adikov.Infrastructura.Commands;
using Adikov.Platform.Settings;

namespace Adikov.Domain.Commands.Contacts
{
    public class EditContactsKeepInTouchCommand : CommandBase
    {
        public ContactsKeepInTouch KeepInTouch { get; set; }
    }

    public class EditContactsKeepInTouchCommandHandler : BaseSettingsCommandHandler<EditContactsKeepInTouchCommand>
    {
        protected override void OnHandling(EditContactsKeepInTouchCommand command, CommandResult result)
        {
            UpdateSettings(command.KeepInTouch);
        }
    }
}