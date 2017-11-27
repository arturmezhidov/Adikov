using System;
using System.Linq;
using System.ComponentModel;

namespace Adikov.Platform.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum e)
        {
            DescriptionAttribute description = e
                .GetType()
                .GetCustomAttributes(typeof(DescriptionAttribute), true)
                .Cast<DescriptionAttribute>()
                .FirstOrDefault();

            return description?.Description;
        }
    }
}