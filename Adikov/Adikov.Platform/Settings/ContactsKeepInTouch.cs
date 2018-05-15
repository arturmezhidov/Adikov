using Adikov.Platform.Attributes;

namespace Adikov.Platform.Settings
{
    public class ContactsKeepInTouch
    {
        [Setting(SettingsKeys.ContactsKeepInTouchTitle)]
        public string Title {get;set;}

        [Setting(SettingsKeys.ContactsKeepInTouchDescription)]
        public string Description { get; set; }

        [Setting(SettingsKeys.ContactsKeepInTouchEmail1)]
        public string Email1 { get; set; }

        [Setting(SettingsKeys.ContactsKeepInTouchEmail2)]
        public string Email2 { get; set; }

        [Setting(SettingsKeys.ContactsKeepInTouchEmail3)]
        public string Email3 { get; set; }

        [Setting(SettingsKeys.ContactsKeepInTouchEmail4)]
        public string Email4 { get; set; }

        [Setting(SettingsKeys.ContactsKeepInTouchIsSendToEmails)]
        public bool IsSendToEmails { get; set; }
    }
}