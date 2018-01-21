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

        public static string GetValueDescription(this Enum e)
        {
            string description = e
                .GetType()
                .GetFieldDescription(e.ToString());

            return description;
        }
    }
}