using Adikov.Platform.Attributes;

namespace Adikov.Platform.Settings
{
    public class ContactsQuestion
    {
        [Setting(SettingsKeys.ContactsQuestionTitle)]
        public string Title { get; set; }

        [Setting(SettingsKeys.ContactsQuestionDescription)]
        public string Description { get; set; }
    }
}