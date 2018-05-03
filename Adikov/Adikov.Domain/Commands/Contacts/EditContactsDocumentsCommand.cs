using Adikov.Domain.Commands.Settings;
using Adikov.Domain.Queries.Contacts;
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
            ContactsDocuments documents = GetDocumentsQuery.Execute().Documents;

            documents.Title = command.Documents.Title;
            documents.Description = command.Documents.Description;

            if (command.File != null)
            {
                documents.FileId = command.File.Id.ToString();
                documents.UpdatedAt = DateTime.Now.ToString();
            }

            UpdateSettings(documents);
        }
    }
}