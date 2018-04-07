using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;
using Adikov.Platform.Attributes;

namespace Adikov.Domain.Commands.Settings
{
    public abstract class BaseSettingsCommandHandler<TCommand> : CommandHandler<TCommand> where TCommand : ICommand
    {
        protected virtual void UpdateSettings(object settingsObj)
        {
            PropertyInfo[] properties = GetProperties(settingsObj);
            string[] keys = GetKeys(properties);
            IDictionary<string, Setting> settings = GetSettings(keys);

            foreach (PropertyInfo property in properties)
            {
                SettingAttribute settingAttribute = property.GetCustomAttribute<SettingAttribute>();

                if (settingAttribute == null)
                {
                    continue;
                }

                string key = settingAttribute.Key;
                string value = property.GetValue(settingsObj)?.ToString();

                if (settings.ContainsKey(key))
                {
                    Setting setting = settings[key];
                    setting.Value = value;
                    DataContext.Entry(setting).State = EntityState.Modified;
                }
                else
                {
                    Setting setting = new Setting
                    {
                        Key = key,
                        Value = value
                    };
                    DataContext.Settings.Add(setting);
                }
            }
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