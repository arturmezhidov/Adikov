using System;

namespace Adikov.Platform.Attributes
{
    public class SettingAttribute : Attribute
    {
        public string Key { get; }

        public SettingAttribute(string key)
        {
            Key = key;
        }
    }
}