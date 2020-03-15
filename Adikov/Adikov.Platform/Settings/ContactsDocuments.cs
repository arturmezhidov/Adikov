using Adikov.Platform.Attributes;

namespace Adikov.Platform.Settings
{
    public class ContactsDocuments
    {
        [Setting(SettingsKeys.ContactsDocumentsTitle)]
        public string Title { get; set; }

        [Setting(SettingsKeys.ContactsDocumentsDescription)]
        public string Description { get; set; }

        [Setting(SettingsKeys.ContactsDocumentsFileId)]
        public string FileId { get; set; }

        [Setting(SettingsKeys.ContactsDocumentsUpdatedAt)]
        public string UpdatedAt { get; set; }
    }
}