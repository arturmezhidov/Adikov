using Adikov.Platform.Attributes;

namespace Adikov.Platform.Settings
{
    public class AboutServices
    {
        [Setting(SettingsKeys.AboutServiceTitle1)]
        public string Title1 { get; set; }

        [Setting(SettingsKeys.AboutServiceDescription1)]
        public string Description1 { get; set; }

        [Setting(SettingsKeys.AboutServiceIcon1)]
        public string Icon1 { get; set; }

        [Setting(SettingsKeys.AboutServiceIconColor1)]
        public string IconColor1 { get; set; }


        [Setting(SettingsKeys.AboutServiceTitle2)]
        public string Title2 { get; set; }

        [Setting(SettingsKeys.AboutServiceDescription2)]
        public string Description2 { get; set; }

        [Setting(SettingsKeys.AboutServiceIcon2)]
        public string Icon2 { get; set; }

        [Setting(SettingsKeys.AboutServiceIconColor2)]
        public string IconColor2 { get; set; }


        [Setting(SettingsKeys.AboutServiceTitle3)]
        public string Title3 { get; set; }

        [Setting(SettingsKeys.AboutServiceDescription3)]
        public string Description3 { get; set; }

        [Setting(SettingsKeys.AboutServiceIcon3)]
        public string Icon3 { get; set; }

        [Setting(SettingsKeys.AboutServiceIconColor3)]
        public string IconColor3 { get; set; }


        [Setting(SettingsKeys.AboutServiceTitle4)]
        public string Title4 { get; set; }

        [Setting(SettingsKeys.AboutServiceDescription4)]
        public string Description4 { get; set; }

        [Setting(SettingsKeys.AboutServiceIcon4)]
        public string Icon4 { get; set; }

        [Setting(SettingsKeys.AboutServiceIconColor4)]
        public string IconColor4 { get; set; }
    }
}