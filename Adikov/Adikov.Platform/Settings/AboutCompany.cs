using Adikov.Platform.Attributes;

namespace Adikov.Platform.Settings
{
    public class AboutCompany
    {
        [Setting(SettingsKeys.AboutCompanyTitle)]
        public string Title { get; set; }

        [Setting(SettingsKeys.AboutCompanyHtmlContent)]
        public string HtmlContent { get; set; }

        [Setting(SettingsKeys.AboutCompanyVideoUrl)]
        public string VideoUrl { get; set; }
    }
}