namespace Adikov.Platform.Configuration
{
    public static class PlatformConfiguration
    {
        public static readonly string ConnectionString = "DefaultConnection";
        public static readonly string UploadedFilesPath = "/UploadedFiles";
        public static readonly string UploadedImagesPath = UploadedFilesPath + "/Images";
        public static readonly string UploadedCategoryPath = UploadedImagesPath + "/Category";
    }
}