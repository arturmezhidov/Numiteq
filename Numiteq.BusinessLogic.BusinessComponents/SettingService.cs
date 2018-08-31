using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.Common.Settings;
using Numiteq.DataAccess.DataContracts;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public class SettingService : DataService<Setting>, ISettingService
    {
        private static readonly Dictionary<string, SettingsObjectInfo> ObjectsInfo = new Dictionary<string, SettingsObjectInfo>();

        public SettingService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public T GetSettings<T>() where T: new()
        {
            T obj = new T();
            SettingsObjectInfo info = GetObjectInfo<T>();
            IDictionary<string, Setting> settings = GetSettings(info.Keys);

            foreach (var property in info.Properties)
            {
                Setting setting = settings[property.Key];
                property.Property.SetValue(obj, setting?.Value);
            }

            return obj;
        }

        public void SaveSettings<T>(T settingsobject)
        {
            SettingsObjectInfo info = GetObjectInfo<T>();
            IDictionary<string, Setting> settings = GetSettings(info.Keys);

            foreach (var property in info.Properties)
            {
                string value = property.Property.GetValue(settingsobject)?.ToString();

                if (settings.ContainsKey(property.Key))
                {
                    Setting setting = settings[property.Key];
                    setting.Value = value;
                    Update(setting);
                }
                else
                {
                    Setting setting = new Setting
                    {
                        Key = property.Key,
                        Value = value
                    };
                    Add(setting);
                }
            }

            Save();
        }

        private IDictionary<string, Setting> GetSettings(string[] keys)
        {
            return GetAll().Where(i => keys.Contains(i.Key)).ToDictionary(i => i.Key, k => k);
        }

        private SettingsObjectInfo GetObjectInfo<T>()
        {
            Type type = typeof(T);
            string key = type.FullName;

            if (!ObjectsInfo.ContainsKey(key))
            {
                ObjectsInfo.Add(key, CreateObjectInfo(type));
            }

            return ObjectsInfo[key];
        }

        private SettingsObjectInfo CreateObjectInfo(Type type)
        {
            SettingsObjectInfo info = new SettingsObjectInfo
            {
                Properties = GetProperties(type)
            };

            info.Keys = GetKeys(type, info.Properties);

            return info;
        }

        private ObjectProperty[] GetProperties(Type type)
        {
            return type.GetProperties().Select(p => new ObjectProperty
            {
                Property = p,
                Key = GetPropertyKey(p)
            }).ToArray();
        }

        private string[] GetKeys(Type type, ObjectProperty[] properties)
        {
            string nameSpace = GetTypeNamespace(type);
            return properties.Select(p => String.Format("{0}.{1}", nameSpace, p.Key)).ToArray();
        }

        private string GetTypeNamespace(Type type)
        {
            return type.GetCustomAttribute<SettingsTypeAttribute>()?.Namespace ?? type.FullName;
        }

        private string GetPropertyKey(PropertyInfo property)
        {
            return property.GetCustomAttribute<SettingsKeyAttribute>()?.Key ?? property.Name;
        }

        private class SettingsObjectInfo
        {
            public string[] Keys { get; set; }

            public ObjectProperty[] Properties { get; set; }
        }

        private class ObjectProperty
        {
            public string Key { get; set; }

            public PropertyInfo Property { get; set; }
        }
    }
}
