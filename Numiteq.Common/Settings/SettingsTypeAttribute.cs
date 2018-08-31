using System;

namespace Numiteq.Common.Settings
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SettingsTypeAttribute : Attribute
    {
        public string Namespace { get; set; }

        public SettingsTypeAttribute(string nameSpace)
        {
            Namespace = nameSpace;
        }
    }
}
