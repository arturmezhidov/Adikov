using Adikov.Domain.Commands.Settings;
using Adikov.Infrastructura.Commands;
using Adikov.Platform.Settings;
using System;

namespace Adikov.Domain.Commands.Contacts
{
    public class EditContactsDocumentsCommand : CommandBase
    {
        public ContactsDocuments Documents { get; set; }

        public Models.File File { get; set; }
    }

    public class EditContactsDocumentsCommandHandler : BaseSettingsCommandHandler<EditContactsDocumentsCommand>
    {
        protected override void OnHandling(EditContactsDocumentsCommand command, CommandResult result)
        {
            if (command.File != null)
            {
                command.Documents.FileId = command.File.Id.ToString();
                command.Documents.UpdatedAt = DateTime.Now.ToString();
            }

            UpdateSettings(command.Documents);
        }
    }
}