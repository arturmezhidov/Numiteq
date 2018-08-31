using System.Linq;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Numiteq.Common.Entities;
using Numiteq.DataAccess.DataContracts;
using Numiteq.DataAccess.Initialization.Data;

namespace Numiteq.DataAccess.Initialization
{
    public class InitializationDataStorage : IInitializationDataStorage
    {
        public List<Setting> GetSettings()
        {
            return parse<Setting>(InitializationData.Settings);
        }

        private List<T> parse<T>(byte[] data)
        {
            var json = Encoding.Default.GetString(data);
            var tokens = JArray.Parse(json);
            var objects = tokens.Select(ct => ct.ToObject<T>()).ToList();
            return objects;
        }
    }
}