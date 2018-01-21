using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Adikov.Platform.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<T> GetAttributes<T>(this Type type) where T: Attribute
        {
            IEnumerable<T> attribues = type
                .GetCustomAttributes(typeof(T), true)
                .Cast<T>();

            return attribues;
        }

        public static T GetAttribute<T>(this Type type) where T : Attribute
        {
            T attribue = type.GetAttributes<T>().FirstOrDefault();

            return attribue;
        }

        public static string GetDescription(this Type type)
        {
            DescriptionAttribute attribute = type.GetAttribute<DescriptionAttribute>();

            return attribute?.Description;
        }

        public static IEnumerable<T> GetFieldAttributes<T>(this Type type, string property) where T : Attribute
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            IEnumerable<T> attribues = type
                .GetField(property)
                .GetCustomAttributes(typeof(T), true)
                .Cast<T>();

            return attribues;
        }

        public static T GetFieldAttribute<T>(this Type type, string property) where T : Attribute
        {
            T attribue = type.GetFieldAttributes<T>(property).FirstOrDefault();

            return attribue;
        }

        public static string GetFieldDescription(this Type type, string property)
        {
            DescriptionAttribute attribute = type.GetFieldAttribute<DescriptionAttribute>(property);

            return attribute?.Description;
        }
    }
}