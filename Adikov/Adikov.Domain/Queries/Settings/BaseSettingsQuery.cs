using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Attributes;

namespace Adikov.Domain.Queries.Settings
{
    public abstract class BaseSettingsQuery<TCriterion, TResponse> : Query<TCriterion, TResponse> where TCriterion : ICriterion where TResponse : class
    {
        protected virtual T GetSettings<T>() where T : new()
        {
            T obj = new T();
            PropertyInfo[] properties = GetProperties(obj);
            string[] keys = GetKeys(properties);
            IDictionary<string, Setting> settings = GetSettings(keys);

            foreach (PropertyInfo property in properties)
            {
                SettingAttribute settingAttribute = property.GetCustomAttribute<SettingAttribute>();

                if (settingAttribute == null)
                {
                    continue;
                }

                if (settings.ContainsKey(settingAttribute.Key))
                {
                    Setting setting = settings[settingAttribute.Key];
                    property.SetValue(obj, setting?.Value);
                }
            }

            return obj;
        }

        protected virtual PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }

        protected virtual string[] GetKeys(PropertyInfo[] properties)
        {
            return properties
                .Select(p => p.GetCustomAttribute<SettingAttribute>()?.Key)
                .Where(p => p != null)
                .ToArray();
        }

        protected virtual IDictionary<string, Setting> GetSettings(params string[] keys)
        {
            return DataContext.Settings.Where(i => keys.Contains(i.Key)).ToDictionary(i => i.Key, k => k);
        }
    }
}