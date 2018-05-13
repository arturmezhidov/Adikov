using System.Configuration;

namespace Adikov.Platform.Configuration
{
    public static class PlatformConfiguration
    {
        public static readonly string ConnectionString = "DefaultConnection";
        public static readonly string LogoPath = "/Content/assets/layouts/layout2/img/logo-default.png";
        public static readonly string UploadedFilesPath = "/UploadedFiles";
        public static readonly string UploadedImagesPath = UploadedFilesPath + "/Images";
        public static readonly string UploadedCategoryPath = UploadedImagesPath + "/Category";
        public static readonly string UploadedSettingsPath = UploadedImagesPath + "/Settings";
        public static readonly string UploadedSettingsPathTemplate = UploadedSettingsPath + "/{0}";
        public static readonly string UploadedUsersPath = UploadedFilesPath + "/Users";
        public static readonly string UploadedUserPathTemplate = UploadedUsersPath + "/User-{0}";
        public static readonly string UploadedUserFilePathTemplate = UploadedUsersPath + "/User-{0}/{1}";
        public static readonly string DefaultAvatarPath = "/Content/img/avatar.jpg";
        public static readonly string DocumentsPath = UploadedFilesPath + "/Documents";
        public static readonly string DocumentsPathTemplate = DocumentsPath + "/{0}";

        public static string SmtpServerName => GetString("SmtpServerName", "smtp.gmail.com");
        public static int SmtpServerPort => GetInt("SmtpServerPort", 587);
        public static string SmtpEmailAddress => GetString("SmtpEmailAddress", "adikov.noreply@gmail.com");
        public static string SmtpEmailPassword => GetString("SmtpEmailPassword", "1q2w#E$R");

        static string GetString(string key, string defaultValue = null)
        {
            string value = ConfigurationManager.AppSettings[key];
            return value ?? defaultValue;
        }
        static int GetInt(string key, int defaultValue = 0)
        {
            string valueStr = GetString(key);
            if(int.TryParse(valueStr, out int value))
            {
                return value;
            }
            return defaultValue;
        }
    }
}