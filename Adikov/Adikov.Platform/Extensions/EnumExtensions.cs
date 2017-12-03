using System;

namespace Adikov.Platform.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum e)
        {
            string description = e
                .GetType()
                .GetDescription();

            return description;
        }
    }
}