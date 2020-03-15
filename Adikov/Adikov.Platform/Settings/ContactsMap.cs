using Adikov.Platform.Attributes;

namespace Adikov.Platform.Settings
{
    public class ContactsMap
    {
        [Setting(SettingsKeys.ContactsMarkerTitle)]
        public string MarkerTitle { get; set; }

        [Setting(SettingsKeys.ContactsLongitude)]
        public string Longitude { get; set; }

        [Setting(SettingsKeys.ContactsLatitude)]
        public string Latitude { get; set; }

        [Setting(SettingsKeys.ContactsMapTitle)]
        public string MapTitle { get; set; }


        [Setting(SettingsKeys.ContactsIsDisplayedAddress)]
        public bool IsDisplayedAddress { get; set; }

        [Setting(SettingsKeys.ContactsAddress)]
        public string Address { get; set; }


        [Setting(SettingsKeys.ContactsIsDisplayedContacts)]
        public bool IsDisplayedContacts { get; set; }

        [Setting(SettingsKeys.ContactsContact1)]
        public string Contact1 { get; set; }

        [Setting(SettingsKeys.ContactsContactIcon1)]
        public string ContactIcon1 { get; set; }

        [Setting(SettingsKeys.ContactsIsDisplayedContact1)]
        public bool IsDisplayedContact1 { get; set; }

        [Setting(SettingsKeys.ContactsContact2)]
        public string Contact2 { get; set; }

        [Setting(SettingsKeys.ContactsContactIcon2)]
        public string ContactIcon2 { get; set; }

        [Setting(SettingsKeys.ContactsIsDisplayedContact2)]
        public bool IsDisplayedContact2 { get; set; }

        [Setting(SettingsKeys.ContactsContact3)]
        public string Contact3 { get; set; }

        [Setting(SettingsKeys.ContactsContactIcon3)]
        public string ContactIcon3 { get; set; }

        [Setting(SettingsKeys.ContactsIsDisplayedContact3)]
        public bool IsDisplayedContact3 { get; set; }


        [Setting(SettingsKeys.ContactsIsDisplayedSocial)]
        public bool IsDisplayedSocial { get; set; }

        [Setting(SettingsKeys.ContactsSocialIcon1)]
        public string SocialIcon1 { get; set; }

        [Setting(SettingsKeys.ContactsSocialLink1)]
        public string SocialLink1 { get; set; }

        [Setting(SettingsKeys.ContactsSocialIcon2)]
        public string SocialIcon2 { get; set; }

        [Setting(SettingsKeys.ContactsSocialLink2)]
        public string SocialLink2 { get; set; }

        [Setting(SettingsKeys.ContactsSocialIcon3)]
        public string SocialIcon3 { get; set; }

        [Setting(SettingsKeys.ContactsSocialLink3)]
        public string SocialLink3 { get; set; }

        [Setting(SettingsKeys.ContactsSocialIcon4)]
        public string SocialIcon4 { get; set; }

        [Setting(SettingsKeys.ContactsSocialLink4)]
        public string SocialLink4 { get; set; }

        [Setting(SettingsKeys.ContactsSocialIcon5)]
        public string SocialIcon5 { get; set; }

        [Setting(SettingsKeys.ContactsSocialLink5)]
        public string SocialLink5 { get; set; }
    }
}