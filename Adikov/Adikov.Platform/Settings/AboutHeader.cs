using Adikov.Platform.Attributes;

namespace Adikov.Platform.Settings
{
    public class AboutHeader
    {
        [Setting(SettingsKeys.AboutHeaderTitle)]
        public string Title { get; set; }

        [Setting(SettingsKeys.AboutHeaderSubTitle)]
        public string SubTitle { get; set; }

        [Setting(SettingsKeys.AboutHeaderLinkText)]
        public string LinkText { get; set; }

        [Setting(SettingsKeys.AboutHeaderLinkUrl)]
        public string LinkUrl { get; set; }

        [Setting(SettingsKeys.AboutHeaderBackgroundImageId)]
        public string BackgroundImageId { get; set; }
    }
}