using Adikov.Platform.Attributes;

namespace Adikov.Platform.Settings
{
    public class AboutMembers
    {
        [Setting(SettingsKeys.AboutCompanyMembersTitle)]
        public string Title { get; set; }

        [Setting(SettingsKeys.AboutCompanyMembersSubTitle)]
        public string SubTitle { get; set; }

        [Setting(SettingsKeys.AboutCompanyMemberId1)]
        public string Member1Id { get; set; }

        [Setting(SettingsKeys.AboutCompanyMemberId2)]
        public string Member2Id { get; set; }

        [Setting(SettingsKeys.AboutCompanyMemberId3)]
        public string Member3Id { get; set; }

        [Setting(SettingsKeys.AboutCompanyMemberId4)]
        public string Member4Id { get; set; }
    }
}