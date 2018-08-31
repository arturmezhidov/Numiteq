using System;

namespace Numiteq.Common.Settings
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SettingsKeyAttribute : Attribute
    {
        public string Key { get; set; }

        public SettingsKeyAttribute(string key)
        {
            Key = key;
        }
    }
}
