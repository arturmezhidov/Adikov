using Adikov.Domain.Commands.Settings;
using Adikov.Infrastructura.Commands;
using Adikov.Platform.Settings;

namespace Adikov.Domain.Commands.Contacts
{
    public class EditContactsQuestionCommand : CommandBase
    {
        public ContactsQuestion Question { get; set; }
    }

    public class EditContactsQuestionCommandHandler : BaseSettingsCommandHandler<EditContactsQuestionCommand>
    {
        protected override void OnHandling(EditContactsQuestionCommand command, CommandResult result)
        {
            UpdateSettings(command.Question);
        }
    }
}