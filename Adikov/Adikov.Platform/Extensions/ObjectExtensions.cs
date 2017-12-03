namespace Adikov.Platform.Extensions
{
    public static class ObjectExtensions
    {
        public static string GetDescription(this object obj)
        {
            return obj.GetType().GetDescription();
        }
    }
}