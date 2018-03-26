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
        public static readonly string DefaultAvatarPath = "/Content/img/avatar.jpg";
    }
}